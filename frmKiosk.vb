Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class frmKiosk
    Private ads As New List(Of String)()
    Private currentAdIndex As Integer = 0
    Private orderType As String = ""
    Private adCacheFolder As String = IO.Path.Combine(Application.StartupPath, "adcache")
    Private inactivityTimer As New Timer()
    Private IdleTimeoutSeconds As Integer = 6
    Private adRotationIntervalSeconds As Integer = 10
    Private selectedCategoryId As Integer = 0
    Private cart As New List(Of OrderItem)
    Private currentProductPrice As Decimal = 0D
    Private adImages As New List(Of Image)
    ' Reliable single place to show one main panel and hide the rest
    Private Sub ShowOnlyPanel(panelToShow As Panel)
        Dim panels As Panel() = {
        pnlIdle,
        pnlOrderStart,
        pnlMain,
        pnlCategories,
        pnlProducts,
        pnlCustomization,
        pnlCart
    }
        For Each p As Panel In panels
            If p IsNot Nothing Then p.Visible = False
        Next

        If panelToShow IsNot Nothing Then
            Dim parentCtrl As Control = panelToShow.Parent
            While parentCtrl IsNot Nothing
                If TypeOf parentCtrl Is Panel Then
                    CType(parentCtrl, Panel).Visible = True
                    parentCtrl.BringToFront()
                End If
                parentCtrl = parentCtrl.Parent
            End While
            panelToShow.Visible = True
            panelToShow.BringToFront()
        End If
    End Sub






    Public Class OrderItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Quantity As Integer
        Public Property Size As String
        Public Property Sugar As String
        Public Property CoffeeLevel As String
        Public Property Milk As String
        Public Property AddOns As String
        Public Property UnitPrice As Decimal
        Public Property TotalPrice As Decimal
    End Class

    ' -------------------------
    ' Form load
    ' -------------------------
    Private Sub frmKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hide debug button from normal users
        btnTestConnection.Visible = False
        Dim adsPath As String = System.IO.Path.Combine(Application.StartupPath, "Ads")
        If System.IO.Directory.Exists(adsPath) Then
            For Each file In System.IO.Directory.GetFiles(adsPath, "*.jpg")
                adImages.Add(Image.FromFile(file))
            Next
        End If
        ' Ensure only idle panel is visible at start
        ShowOnlyPanel(pnlIdle)
        pnlTop.Visible = False
        SetCartTrayVisible(False)

        ' Load ads and start rotation if available
        Try
            LoadAdvertisements()
            If ads.Count > 0 Then
                DisplayAd(0)
                TimerAds.Interval = 5000
                TimerAds.Start()
            Else
                lblIdleInfo.Text = "No ads found in database."
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing kiosk: " & ex.Message)
        End Try

        ' Initialize inactivity timer and attach activity 

        TimerClock.Interval = 1000
        TimerClock.Enabled = True

        TimerAds.Interval = 5000
        TimerAds.Enabled = True

        InitializeInactivityTimer()
        AttachUserActivityHandlers(Me)

    End Sub


    ' -------------------------
    ' Advertisements (Idle)
    ' -------------------------
    Private Sub LoadAdvertisements()
        ads.Clear()
        Try
            ' Ensure cache folder exists
            If Not IO.Directory.Exists(adCacheFolder) Then IO.Directory.CreateDirectory(adCacheFolder)

            conn.Open()
            Dim cmd As New MySqlCommand("SELECT image_path FROM advertisements ORDER BY id", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim rawPath As String = reader("image_path").ToString().Trim()
                If String.IsNullOrEmpty(rawPath) Then Continue While

                ' If remote URL, add URL directly (we will download later)
                If rawPath.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then
                    ads.Add(rawPath)
                Else
                    ' Normalize separators and common missing-slash pattern
                    rawPath = rawPath.Replace("/", "\").TrimStart("\"c)
                    Dim fullPath As String = If(IO.Path.IsPathRooted(rawPath),
                                           rawPath,
                                           IO.Path.Combine(Application.StartupPath, rawPath))
                    ads.Add(fullPath)
                End If
            End While
            reader.Close()
        Catch
            ' ignore DB errors here; keep ads empty if fail
        Finally
            conn.Close()
        End Try
    End Sub




    Private Sub DisplayAd(index As Integer)
        Try
            If picIdle.Image IsNot Nothing Then
                picIdle.Image.Dispose()
                picIdle.Image = Nothing
            End If

            Dim imgPath As String = ads(index)
            If File.Exists(imgPath) Then
                picIdle.Image = Image.FromFile(imgPath)
                lblIdleInfo.Text = "Showing ad " & (index + 1).ToString() & " of " & ads.Count.ToString()
            Else
                lblIdleInfo.Text = "Image not found: " & imgPath
            End If
        Catch ex As Exception
            lblIdleInfo.Text = "Error displaying ad: " & ex.Message
        End Try
    End Sub

    Private Sub TimerAds_Tick(sender As Object, e As EventArgs) Handles TimerAds.Tick
        If adImages.Count = 0 Then Return
        currentAdIndex = (currentAdIndex + 1) Mod adImages.Count

        ' Idle ads
        If picIdle IsNot Nothing AndAlso pnlIdle.Visible Then
            picIdle.Image = adImages(currentAdIndex)
        End If

        ' Top panel ads
        If picAds IsNot Nothing AndAlso pnlTop.Visible Then
            picAds.Image = adImages(currentAdIndex)
        End If
    End Sub



    Private Sub frmKiosk_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If picIdle.Image IsNot Nothing Then
            picIdle.Image.Dispose()
            picIdle.Image = Nothing
        End If
    End Sub

    ' -------------------------
    ' Idle -> Start (touch to begin)
    ' -------------------------
    Private Sub pnlIdle_Click(sender As Object, e As EventArgs) Handles pnlIdle.Click, picIdle.Click, lblIdleInfo.Click
        TimerAds.Stop()
        ShowOnlyPanel(pnlOrderStart)
        pnlTop.Visible = False
        ResetInactivityTimer()
    End Sub

    ' Show categories and tray after choosing order type
    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
        orderType = "Dine In"
        ShowOnlyPanel(pnlCategories)
        pnlTop.Visible = True
        LoadCategories()
        SetCartTrayVisible(True)
        ResetInactivityTimer()
    End Sub

    Private Sub btnTakeOut_Click(sender As Object, e As EventArgs) Handles btnTakeOut.Click
        orderType = "Take Out"
        ShowOnlyPanel(pnlCategories)
        pnlTop.Visible = True
        LoadCategories()
        SetCartTrayVisible(True)
        ResetInactivityTimer()
    End Sub





    ' -------------------------
    ' Load categories from DB into flpCategories
    ' -------------------------
    ' Load categories into flpCategories (call this when showing categories)
    Private Sub LoadCategories()
        flpCategories.Controls.Clear()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT id, category_name FROM categories ORDER BY id", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim catId As Integer = CInt(reader("id"))
                Dim catName As String = reader("category_name").ToString()

                Dim catTile As Panel = CreateTile(catName, "", "", catId, AddressOf CategoryTile_Click)
                flpCategories.Controls.Add(catTile)
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Private Sub Category_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim catId As Integer = CInt(btn.Tag)
        selectedCategoryId = catId
        LoadProducts(catId)        ' loads products into flpProducts
        ShowOnlyPanel(pnlProducts)
        pnlTop.Visible = True ' show the products panel
        ResetInactivityTimer()
    End Sub



    ' -------------------------
    ' Test connection button (kept for debugging)
    ' -------------------------
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            conn.Open()
            MessageBox.Show("Connection successful!")
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Initialize inactivity timer
    Private Sub InitializeInactivityTimer()
        inactivityTimer.Interval = IdleTimeoutSeconds * 1000
        AddHandler inactivityTimer.Tick, AddressOf InactivityTimer_Tick
        inactivityTimer.Stop()
    End Sub

    Private Sub InactivityTimer_Tick(sender As Object, e As EventArgs)
        inactivityTimer.Stop()
        ReturnToIdle()
    End Sub

    Private Sub ResetInactivityTimer()
        Try
            If pnlIdle.Visible = False Then
                inactivityTimer.Stop()
                inactivityTimer.Interval = IdleTimeoutSeconds * 1000
                inactivityTimer.Start()
            End If
        Catch
            ' ignore timer errors
        End Try
    End Sub

    Private Sub AnyUserActivity(sender As Object, e As EventArgs)
        ResetInactivityTimer()
    End Sub

    Private Sub AttachUserActivityHandlers(parent As Control)
        For Each ctrl As Control In parent.Controls
            Try
                AddHandler ctrl.Click, AddressOf AnyUserActivity
                AddHandler ctrl.MouseMove, AddressOf AnyUserActivity
                AddHandler ctrl.KeyDown, AddressOf AnyUserActivity
            Catch
                ' some controls may not support events; ignore
            End Try
            If ctrl.HasChildren Then
                AttachUserActivityHandlers(ctrl)
            End If
        Next
    End Sub

    Private Sub ReturnToIdle()
        Try
            inactivityTimer.Stop()

            ' TODO: clear cart and temporary selections if you have them
            ' Example: cart.Clear()

            ShowOnlyPanel(pnlIdle)

            pnlTop.Visible = False
            SetCartTrayVisible(False)


            ' Reload ads and restart rotation
            LoadAdvertisements()
            If ads.Count > 0 Then
                currentAdIndex = 0
                DisplayAdIn(picIdle, 0)
                DisplayAdIn(picIdle, 0)
                TimerAds.Interval = adRotationIntervalSeconds * 1000
                TimerAds.Start()
            End If

            lblIdleInfo.Text = "Touch screen to start"
        Catch
            ' swallow exceptions to avoid kiosk crash
        End Try
    End Sub

    ' Ensure you declared selectedProductId and cart earlier; selectedProductId used later
    Private Sub LoadProducts(categoryId As Integer)
        flpProducts.Controls.Clear()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT id, product_name, price, image_path FROM products WHERE category_id=@cat ORDER BY id", conn)
            cmd.Parameters.AddWithValue("@cat", categoryId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim prodId As Integer = CInt(reader("id"))
                Dim prodName As String = reader("product_name").ToString()
                Dim prodPrice As Decimal = 0D
                Decimal.TryParse(reader("price").ToString(), prodPrice)
                Dim imgPathRaw As String = reader("image_path").ToString()

                Dim priceText As String = "₱ " & prodPrice.ToString("F2")
                Dim prodTile As Panel = CreateTile(prodName, priceText, imgPathRaw, prodId, AddressOf ProductTile_Click)

                flpProducts.Controls.Add(prodTile)
            End While
            reader.Close()

            ' Center content after adding tiles

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private selectedProductId As Integer = 0

    Private Sub Product_Click(productId As Integer)
        selectedProductId = productId
        ' Show customization panel and hide tray
        ShowOnlyPanel(pnlCustomization)
        SetCartTrayVisible(False)
        pnlTop.Visible = False
        LoadCustomizationForProduct(productId)
        ResetInactivityTimer()
    End Sub

    Private Sub btnCustomizationBack_Click(sender As Object, e As EventArgs) Handles btnCustomizationBack.Click
        ' Return to products for the previously selected category
        ShowOnlyPanel(pnlProducts)
        pnlTop.Visible = True
        SetCartTrayVisible(True)
        ' Reload products to ensure UI is repopulated and layout is correct
        LoadProducts(selectedCategoryId)
        ResetInactivityTimer()
    End Sub


    Private Sub btnCategoriesBack_Click(sender As Object, e As EventArgs) Handles btnCategoriesBack.Click
        ' Return to order start or idle as you prefer
        ShowOnlyPanel(pnlOrderStart)
        pnlTop.Visible = False
        ResetInactivityTimer()
    End Sub

    Private Sub btnProductsBack_Click(sender As Object, e As EventArgs) Handles btnProductsBack.Click
        ShowOnlyPanel(pnlCategories)
        pnlTop.Visible = True

        ResetInactivityTimer()
    End Sub

    Private Function CreateTile(title As String, priceText As String, imagePath As String, tagValue As Object, clickHandler As EventHandler) As Panel
        Dim tile As New Panel With {
            .Width = 260,
            .Height = 300,
            .BackColor = Color.White,
            .Margin = New Padding(12),
            .Tag = tagValue,
            .Cursor = Cursors.Hand
        }

        ' Rounded card drawing
        AddHandler tile.Paint, Sub(s, e)
                                   Dim r As Rectangle = New Rectangle(0, 0, tile.Width - 1, tile.Height - 1)
                                   Using gp As New System.Drawing.Drawing2D.GraphicsPath()
                                       Dim radius As Integer = 14
                                       gp.AddArc(r.X, r.Y, radius, radius, 180, 90)
                                       gp.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90)
                                       gp.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90)
                                       gp.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90)
                                       gp.CloseFigure()
                                       e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                       Using brush As New SolidBrush(tile.BackColor)
                                           e.Graphics.FillPath(brush, gp)
                                       End Using
                                       Using pen As New Pen(Color.FromArgb(220, 220, 220))
                                           e.Graphics.DrawPath(pen, gp)
                                       End Using
                                   End Using
                               End Sub

        ' PictureBox
        Dim pb As New PictureBox With {
            .Width = tile.Width - 24,
            .Height = 160,
            .Top = 12,
            .Left = 12,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BackColor = Color.FromArgb(245, 245, 245)
        }
        If Not String.IsNullOrEmpty(imagePath) Then
            Try
                Dim fullImg As String = If(System.IO.Path.IsPathRooted(imagePath), imagePath, System.IO.Path.Combine(Application.StartupPath, imagePath.Replace("/", "\")))
                If System.IO.File.Exists(fullImg) Then
                    Dim bytes() As Byte = System.IO.File.ReadAllBytes(fullImg)
                    Using ms As New IO.MemoryStream(bytes)
                        Using loadedImg As Image = Image.FromStream(ms)
                            pb.Image = New Bitmap(loadedImg)
                        End Using
                    End Using
                End If
            Catch
                pb.Image = Nothing
            End Try
        End If

        ' Title
        Dim lblTitle As New Label With {
            .Text = title,
            .AutoSize = False,
            .Width = tile.Width - 24,
            .Height = 48,
            .Top = pb.Bottom + 8,
            .Left = 12,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(45, 45, 45)
        }

        ' Price (optional)
        Dim lblPrice As New Label With {
            .Text = priceText,
            .AutoSize = False,
            .Width = tile.Width - 24,
            .Height = 28,
            .Top = lblTitle.Bottom + 6,
            .Left = 12,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.FromArgb(0, 120, 0)
        }
        If String.IsNullOrEmpty(priceText) Then lblPrice.Visible = False

        ' Hover effect
        AddHandler tile.MouseEnter, Sub() tile.BackColor = Color.FromArgb(250, 245, 240)
        AddHandler tile.MouseLeave, Sub() tile.BackColor = Color.White

        ' Click handlers
        AddHandler tile.Click, clickHandler
        AddHandler pb.Click, clickHandler
        AddHandler lblTitle.Click, clickHandler
        AddHandler lblPrice.Click, clickHandler

        tile.Controls.Add(pb)
        tile.Controls.Add(lblTitle)
        tile.Controls.Add(lblPrice)

        Return tile
    End Function

    ' Centering logic for FlowLayoutPanel


    Private Sub CategoryTile_Click(sender As Object, e As EventArgs)
        ' Determine the tile panel (sender may be child control)
        Dim ctrl As Control = TryCast(sender, Control)
        While ctrl IsNot Nothing AndAlso Not TypeOf ctrl Is Panel
            ctrl = ctrl.Parent
        End While
        If ctrl Is Nothing Then Return
        Dim catId As Integer = CInt(ctrl.Tag)
        selectedCategoryId = catId
        LoadProducts(catId)
        ShowOnlyPanel(pnlProducts)
        pnlTop.Visible = True
        ResetInactivityTimer()
    End Sub

    Private Sub ProductTile_Click(sender As Object, e As EventArgs)
        Dim ctrl As Control = TryCast(sender, Control)
        While ctrl IsNot Nothing AndAlso Not TypeOf ctrl Is Panel
            ctrl = ctrl.Parent
        End While
        If ctrl Is Nothing Then Return
        Dim prodId As Integer = CInt(ctrl.Tag)
        selectedProductId = prodId
        Product_Click(prodId)
    End Sub

    Private Function EnsureLocalAdFile(adSource As String) As String
        Try
            If String.IsNullOrEmpty(adSource) Then Return ""
            If adSource.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then
                Dim fileName As String = IO.Path.GetFileName(New Uri(adSource).LocalPath)
                If String.IsNullOrEmpty(fileName) Then fileName = "ad_" & Guid.NewGuid().ToString() & ".jpg"
                Dim localPath As String = IO.Path.Combine(adCacheFolder, fileName)
                If Not IO.File.Exists(localPath) Then
                    Using wc As New Net.WebClient()
                        wc.DownloadFile(adSource, localPath)
                    End Using
                End If
                Return localPath
            Else
                Return adSource
            End If
        Catch
            Return ""
        End Try
    End Function

    Private Sub DisplayAdIn(pb As PictureBox, index As Integer)
        Try
            If ads Is Nothing OrElse ads.Count = 0 Then
                pb.Image = Nothing
                Return
            End If

            Dim src As String = ads(index Mod ads.Count)
            Dim localPath As String = EnsureLocalAdFile(src)
            If String.IsNullOrEmpty(localPath) OrElse Not IO.File.Exists(localPath) Then
                ' show placeholder or clear
                pb.Image = Nothing
                Return
            End If

            ' Dispose previous image to avoid memory leak
            If pb.Image IsNot Nothing Then
                pb.Image.Dispose()
                pb.Image = Nothing
            End If

            Dim bytes() As Byte = IO.File.ReadAllBytes(localPath)
            Using ms As New IO.MemoryStream(bytes)
                Using loadedImg As Image = Image.FromStream(ms)
                    pb.Image = New Bitmap(loadedImg)
                End Using
            End Using
        Catch
            ' ignore display errors
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblTime.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlCartFooter.Paint

    End Sub

    ' Call this after any change to cart
    Private Sub UpdateCartTray()
        Dim count As Integer = cart.Sum(Function(i) i.Quantity)
        Dim total As Decimal = cart.Sum(Function(i) i.TotalPrice)
        lblCartCount.Text = "Items: " & count.ToString()
        lblCartTotal.Text = "TOTAL: ₱ " & total.ToString("F2")
        If cart.Count > 0 Then
            Dim last As OrderItem = cart.Last()
            lblRecentItem.Text = last.ProductName & " x" & last.Quantity.ToString()
        Else
            lblRecentItem.Text = "Your tray is empty!"
        End If
    End Sub

    ' Example: call this when user confirms Add To Cart in customization
    Private Sub AddToCart(productId As Integer, productName As String, qty As Integer, unitPrice As Decimal, addons As String)
        Dim item As New OrderItem With {
        .ProductId = productId,
        .ProductName = productName,
        .Quantity = qty,
        .UnitPrice = unitPrice,
        .AddOns = addons,
        .TotalPrice = unitPrice * qty
    }
        cart.Add(item)
        UpdateCartTray()
    End Sub

    Private Sub btnViewCart_Click(sender As Object, e As EventArgs) Handles btnViewCart.Click
        LoadCartDetails()
        ShowOnlyPanel(pnlCart)
        SetCartTrayVisible(False) ' hide tray while viewing full cart
    End Sub



    Private Sub LoadCartDetails()
        flpCartItems.Controls.Clear()
        For Each it In cart
            Dim itemPanel As New Panel With {
            .Width = flpCartItems.ClientSize.Width - 24,
            .Height = 72,
            .BackColor = Color.FromArgb(250, 250, 250),
            .Margin = New Padding(6)
        }

            Dim lblName As New Label With {
            .Text = it.ProductName & If(String.IsNullOrEmpty(it.AddOns), "", " (" & it.AddOns & ")"),
            .AutoSize = False,
            .Width = itemPanel.Width - 140,
            .Height = 36,
            .Top = 8,
            .Left = 8,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
        }

            Dim lblQty As New Label With {
            .Text = "Qty: " & it.Quantity.ToString(),
            .AutoSize = False,
            .Width = 80,
            .Height = 24,
            .Top = 8,
            .Left = itemPanel.Width - 120,
            .TextAlign = ContentAlignment.MiddleLeft
        }

            Dim lblPrice As New Label With {
            .Text = "₱ " & it.TotalPrice.ToString("F2"),
            .AutoSize = False,
            .Width = 120,
            .Height = 24,
            .Top = 36,
            .Left = itemPanel.Width - 140,
            .TextAlign = ContentAlignment.MiddleLeft,
            .ForeColor = Color.FromArgb(0, 120, 0)
        }

            Dim btnRemove As New Button With {
            .Text = "Remove",
            .Width = 80,
            .Height = 28,
            .Top = 20,
            .Left = itemPanel.Width - 220,
            .BackColor = Color.LightCoral,
            .ForeColor = Color.White,
            .Tag = it
        }
            AddHandler btnRemove.Click, Sub(s, ev) RemoveFromCart(CType(CType(s, Button).Tag, OrderItem))

            itemPanel.Controls.Add(lblName)
            itemPanel.Controls.Add(lblQty)
            itemPanel.Controls.Add(lblPrice)
            itemPanel.Controls.Add(btnRemove)

            flpCartItems.Controls.Add(itemPanel)
        Next

        ' Update footer total
        Dim total As Decimal = cart.Sum(Function(i) i.TotalPrice)
        lblCartFooterTotal.Text = "TOTAL: ₱ " & total.ToString("F2")
    End Sub

    Private Sub RemoveFromCart(item As OrderItem)
        If item Is Nothing Then Return
        cart.Remove(item)
        UpdateCartTray()
        LoadCartDetails()
    End Sub

    Private Sub btnCancelCart_Click(sender As Object, e As EventArgs) Handles btnCancelCart.Click
        ' Close cart view and return to products or categories
        ShowOnlyPanel(pnlProducts)
        pnlTop.Visible = True
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        ' Implement order persistence or next step
        MessageBox.Show("Proceeding to checkout. Items: " & cart.Count.ToString())
        ' After checkout clear cart
        cart.Clear()
        UpdateCartTray()
        ShowOnlyPanel(pnlOrderStart) ' or idle
        pnlTop.Visible = False
    End Sub

    Private Sub DebugPanelState()
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("pnlMain Visible: " & If(pnlMain IsNot Nothing, pnlMain.Visible.ToString(), "null"))
        sb.AppendLine("pnlMain Bounds: " & If(pnlMain IsNot Nothing, pnlMain.Bounds.ToString(), "null"))
        sb.AppendLine("pnlCategories Visible: " & If(pnlCategories IsNot Nothing, pnlCategories.Visible.ToString(), "null"))
        sb.AppendLine("pnlCategories Bounds: " & If(pnlCategories IsNot Nothing, pnlCategories.Bounds.ToString(), "null"))
        sb.AppendLine("flpCategories Controls: " & If(flpCategories IsNot Nothing, flpCategories.Controls.Count.ToString(), "null"))
        sb.AppendLine("pnlProducts Visible: " & If(pnlProducts IsNot Nothing, pnlProducts.Visible.ToString(), "null"))
        sb.AppendLine("pnlProducts Bounds: " & If(pnlProducts IsNot Nothing, pnlProducts.Bounds.ToString(), "null"))
        sb.AppendLine("flpProducts Controls: " & If(flpProducts IsNot Nothing, flpProducts.Controls.Count.ToString(), "null"))
        MessageBox.Show(sb.ToString(), "Panel debug")
    End Sub

    Private Sub cmbSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSize.SelectedIndexChanged, cmbSugar.SelectedIndexChanged, cmbMilk.SelectedIndexChanged, cmbCoffee.SelectedIndexChanged

    End Sub

    Private Sub LoadCustomizationForProduct(productId As Integer)
        flpAddOns.Controls.Clear()
        nudQuantity.Value = 1
        lblCustomPrice.Text = "₱ 0.00"
        currentProductPrice = 0D

        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT product_name, price, image_path FROM products WHERE id=@id", conn)
            cmd.Parameters.AddWithValue("@id", productId)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                lblProductName.Text = reader("product_name").ToString()
                Decimal.TryParse(reader("price").ToString(), currentProductPrice)
                Dim imgPathRaw As String = reader("image_path").ToString()
                picProduct.Image = Nothing
                If Not String.IsNullOrEmpty(imgPathRaw) Then
                    Dim fullImgPath As String = If(System.IO.Path.IsPathRooted(imgPathRaw), imgPathRaw, System.IO.Path.Combine(Application.StartupPath, imgPathRaw.Replace("/", "\")))
                    If System.IO.File.Exists(fullImgPath) Then
                        Dim bytes() As Byte = System.IO.File.ReadAllBytes(fullImgPath)
                        Using ms As New IO.MemoryStream(bytes)
                            Using loadedImg As Image = Image.FromStream(ms)
                                picProduct.Image = New Bitmap(loadedImg)
                            End Using
                        End Using
                    End If
                End If
            End If
            reader.Close()

            Dim cmd2 As New MySqlCommand("SELECT id, addon_name, addon_price FROM addons ORDER BY id", conn)
            Dim rdr2 As MySqlDataReader = cmd2.ExecuteReader()
            While rdr2.Read()
                Dim cb As New CheckBox With {
                .Text = rdr2("addon_name").ToString() & " (₱ " & Convert.ToDecimal(rdr2("addon_price")).ToString("F2") & ")",
                .AutoSize = True,
                .Tag = Convert.ToDecimal(rdr2("addon_price"))
            }
                AddHandler cb.CheckedChanged, AddressOf UpdateCustomPrice
                flpAddOns.Controls.Add(cb)
            End While
            rdr2.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading customization: " & ex.Message)
        Finally
            conn.Close()
        End Try

        If cmbSize.Items.Count = 0 Then cmbSize.Items.AddRange(New String() {"Small", "Regular", "Large"}) : cmbSize.SelectedIndex = 1
        If cmbSugar.Items.Count = 0 Then cmbSugar.Items.AddRange(New String() {"0%", "25%", "50%", "75%", "100%"}) : cmbSugar.SelectedIndex = 4
        If cmbCoffee.Items.Count = 0 Then cmbCoffee.Items.AddRange(New String() {"Light", "Regular", "Strong"}) : cmbCoffee.SelectedIndex = 1
        If cmbMilk.Items.Count = 0 Then cmbMilk.Items.AddRange(New String() {"None", "Whole", "Skim", "Soy", "Oat"}) : cmbMilk.SelectedIndex = 0

        RemoveHandler nudQuantity.ValueChanged, AddressOf UpdateCustomPrice
        AddHandler nudQuantity.ValueChanged, AddressOf UpdateCustomPrice
        RemoveHandler cmbSize.SelectedIndexChanged, AddressOf UpdateCustomPrice
        AddHandler cmbSize.SelectedIndexChanged, AddressOf UpdateCustomPrice
        RemoveHandler cmbSugar.SelectedIndexChanged, AddressOf UpdateCustomPrice
        AddHandler cmbSugar.SelectedIndexChanged, AddressOf UpdateCustomPrice
        RemoveHandler cmbCoffee.SelectedIndexChanged, AddressOf UpdateCustomPrice
        AddHandler cmbCoffee.SelectedIndexChanged, AddressOf UpdateCustomPrice
        RemoveHandler cmbMilk.SelectedIndexChanged, AddressOf UpdateCustomPrice
        AddHandler cmbMilk.SelectedIndexChanged, AddressOf UpdateCustomPrice

        UpdateCustomPrice()
    End Sub


    Private Function GetSizeMultiplier(size As String) As Decimal
        Select Case size
            Case "Small" : Return 0.9D
            Case "Regular" : Return 1D
            Case "Large" : Return 1.25D
            Case Else : Return 1D
        End Select
    End Function

    Private Sub UpdateCustomPrice()
        Dim qty As Integer = CInt(nudQuantity.Value)
        Dim sizeMult As Decimal = GetSizeMultiplier(If(cmbSize.SelectedItem?.ToString(), "Regular"))
        Dim addonsTotal As Decimal = 0D
        For Each ctrl As Control In flpAddOns.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb As CheckBox = CType(ctrl, CheckBox)
                If cb.Checked Then addonsTotal += Convert.ToDecimal(cb.Tag)
            End If
        Next
        Dim total As Decimal = (currentProductPrice * sizeMult + addonsTotal) * qty
        lblCustomPrice.Text = "₱ " & total.ToString("F2")
    End Sub

    Private Function GetSelectedAddOns() As String
        Dim list As New List(Of String)
        For Each ctrl As Control In flpAddOns.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb As CheckBox = CType(ctrl, CheckBox)
                If cb.Checked Then list.Add(cb.Text)
            End If
        Next
        Return String.Join("; ", list)
    End Function

    ' Add to cart button handler
    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        ' Build OrderItem from customization controls (example)
        Dim qty As Integer = CInt(nudQuantity.Value)
        Dim unitPrice As Decimal = currentProductPrice ' set by LoadCustomizationForProduct
        Dim addons As String = GetSelectedAddOns()
        AddToCart(selectedProductId, lblProductName.Text, qty, unitPrice, addons)

        ' Return to products and show tray
        ShowOnlyPanel(pnlProducts)
        pnlTop.Visible = True
        SetCartTrayVisible(True)
        LoadProducts(selectedCategoryId)
        ResetInactivityTimer()
    End Sub

    ' Call SetCartTrayVisible(True) to show tray and reserve space
    ' Reserve space and show/hide cart tray
    Private Sub SetCartTrayVisible(show As Boolean)
        If pnlCartTray Is Nothing OrElse pnlMain Is Nothing Then Return
        If show Then
            pnlCartTray.Visible = True
            pnlCartTray.BringToFront()
            pnlMain.Padding = New Padding(pnlMain.Padding.Left, pnlMain.Padding.Top, pnlCartTray.Width, pnlMain.Padding.Bottom)
        Else
            pnlCartTray.Visible = False
            pnlMain.Padding = New Padding(pnlMain.Padding.Left, pnlMain.Padding.Top, 0, pnlMain.Padding.Bottom)
        End If
    End Sub

    Private Sub btnCartBack_Click(sender As Object, e As EventArgs) Handles btnCancelCart.Click
        ' Decide where to return: prefer products if a category is selected
        If selectedCategoryId > 0 Then
            ShowOnlyPanel(pnlProducts)
            pnlTop.Visible = True
            SetCartTrayVisible(True)
            LoadProducts(selectedCategoryId)
        Else
            ShowOnlyPanel(pnlCategories)
            pnlTop.Visible = True
            SetCartTrayVisible(True)
            LoadCategories()
        End If
    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick
        lblTime.Text = DateTime.Now.ToString("hh:mm tt") & " " & DateTime.Now.ToString("MMMM dd, yyyy")
    End Sub


End Class
