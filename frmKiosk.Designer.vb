<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKiosk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKiosk))
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.pnlIdle = New System.Windows.Forms.Panel()
        Me.lblIdleInfo = New System.Windows.Forms.Label()
        Me.picIdle = New System.Windows.Forms.PictureBox()
        Me.TimerAds = New System.Windows.Forms.Timer(Me.components)
        Me.pnlOrderStart = New System.Windows.Forms.Panel()
        Me.btnTakeOut = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDineIn = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlCategories = New System.Windows.Forms.Panel()
        Me.btnCategoriesBack = New Guna.UI2.WinForms.Guna2Button()
        Me.flpCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlProducts = New System.Windows.Forms.Panel()
        Me.btnProductsBack = New Guna.UI2.WinForms.Guna2Button()
        Me.flpProducts = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAdCaption = New System.Windows.Forms.Label()
        Me.picAds = New System.Windows.Forms.PictureBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlCartTray = New System.Windows.Forms.Panel()
        Me.btnViewCart = New Guna.UI2.WinForms.Guna2Button()
        Me.lblCartTotal = New System.Windows.Forms.Label()
        Me.lblCartCount = New System.Windows.Forms.Label()
        Me.lblRecentItem = New System.Windows.Forms.Label()
        Me.lblCartTitle = New System.Windows.Forms.Label()
        Me.pnlCart = New System.Windows.Forms.Panel()
        Me.pnlCartFooter = New System.Windows.Forms.Panel()
        Me.btnCancelCart = New Guna.UI2.WinForms.Guna2Button()
        Me.btnCheckout = New Guna.UI2.WinForms.Guna2Button()
        Me.lblCartFooterTotal = New System.Windows.Forms.Label()
        Me.flpCartItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCartHeader = New System.Windows.Forms.Label()
        Me.pnlCustomization = New System.Windows.Forms.Panel()
        Me.btnCustomizationBack = New Guna.UI2.WinForms.Guna2Button()
        Me.btnAddToCart = New Guna.UI2.WinForms.Guna2Button()
        Me.flpAddOns = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblmilk = New System.Windows.Forms.Label()
        Me.lblsugar = New System.Windows.Forms.Label()
        Me.lblcoffee = New System.Windows.Forms.Label()
        Me.cmbMilk = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbCoffee = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbSugar = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cmbSize = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.nudQuantity = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.lblCustomPrice = New System.Windows.Forms.Label()
        Me.lblsize = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.pnlIdle.SuspendLayout()
        CType(Me.picIdle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOrderStart.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.pnlProducts.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        CType(Me.picAds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.pnlCartTray.SuspendLayout()
        Me.pnlCart.SuspendLayout()
        Me.pnlCartFooter.SuspendLayout()
        Me.pnlCustomization.SuspendLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTestConnection
        '
        Me.btnTestConnection.AutoSize = True
        Me.btnTestConnection.BackColor = System.Drawing.Color.Black
        Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestConnection.Location = New System.Drawing.Point(0, 0)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(122, 47)
        Me.btnTestConnection.TabIndex = 0
        Me.btnTestConnection.Text = "Button1"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'pnlIdle
        '
        Me.pnlIdle.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.pnlIdle.Controls.Add(Me.lblIdleInfo)
        Me.pnlIdle.Controls.Add(Me.picIdle)
        Me.pnlIdle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIdle.Location = New System.Drawing.Point(0, 0)
        Me.pnlIdle.Name = "pnlIdle"
        Me.pnlIdle.Size = New System.Drawing.Size(1113, 634)
        Me.pnlIdle.TabIndex = 1
        '
        'lblIdleInfo
        '
        Me.lblIdleInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.lblIdleInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblIdleInfo.Location = New System.Drawing.Point(0, 604)
        Me.lblIdleInfo.Name = "lblIdleInfo"
        Me.lblIdleInfo.Size = New System.Drawing.Size(1113, 30)
        Me.lblIdleInfo.TabIndex = 1
        Me.lblIdleInfo.Text = "Label1"
        Me.lblIdleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picIdle
        '
        Me.picIdle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picIdle.Location = New System.Drawing.Point(0, 0)
        Me.picIdle.Name = "picIdle"
        Me.picIdle.Size = New System.Drawing.Size(1113, 634)
        Me.picIdle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIdle.TabIndex = 0
        Me.picIdle.TabStop = False
        '
        'TimerAds
        '
        Me.TimerAds.Interval = 5000
        '
        'pnlOrderStart
        '
        Me.pnlOrderStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.pnlOrderStart.Controls.Add(Me.btnTakeOut)
        Me.pnlOrderStart.Controls.Add(Me.btnDineIn)
        Me.pnlOrderStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrderStart.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOrderStart.Location = New System.Drawing.Point(0, 0)
        Me.pnlOrderStart.Name = "pnlOrderStart"
        Me.pnlOrderStart.Size = New System.Drawing.Size(1113, 634)
        Me.pnlOrderStart.TabIndex = 2
        Me.pnlOrderStart.Visible = False
        '
        'btnTakeOut
        '
        Me.btnTakeOut.BackColor = System.Drawing.Color.Transparent
        Me.btnTakeOut.BorderRadius = 40
        Me.btnTakeOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTakeOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTakeOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTakeOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTakeOut.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnTakeOut.Font = New System.Drawing.Font("Comic Sans MS", 47.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTakeOut.ForeColor = System.Drawing.Color.White
        Me.btnTakeOut.Image = CType(resources.GetObject("btnTakeOut.Image"), System.Drawing.Image)
        Me.btnTakeOut.ImageOffset = New System.Drawing.Point(80, -50)
        Me.btnTakeOut.ImageSize = New System.Drawing.Size(190, 190)
        Me.btnTakeOut.Location = New System.Drawing.Point(767, 139)
        Me.btnTakeOut.Name = "btnTakeOut"
        Me.btnTakeOut.ShadowDecoration.BorderRadius = 40
        Me.btnTakeOut.ShadowDecoration.Enabled = True
        Me.btnTakeOut.Size = New System.Drawing.Size(350, 450)
        Me.btnTakeOut.TabIndex = 1
        Me.btnTakeOut.Text = "Take Out"
        Me.btnTakeOut.TextOffset = New System.Drawing.Point(-49, 110)
        '
        'btnDineIn
        '
        Me.btnDineIn.BackColor = System.Drawing.Color.Transparent
        Me.btnDineIn.BorderRadius = 40
        Me.btnDineIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDineIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDineIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDineIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDineIn.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDineIn.Font = New System.Drawing.Font("Comic Sans MS", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDineIn.ForeColor = System.Drawing.Color.White
        Me.btnDineIn.Image = CType(resources.GetObject("btnDineIn.Image"), System.Drawing.Image)
        Me.btnDineIn.ImageOffset = New System.Drawing.Point(73, -60)
        Me.btnDineIn.ImageSize = New System.Drawing.Size(200, 200)
        Me.btnDineIn.Location = New System.Drawing.Point(284, 139)
        Me.btnDineIn.Name = "btnDineIn"
        Me.btnDineIn.ShadowDecoration.BorderRadius = 40
        Me.btnDineIn.ShadowDecoration.Enabled = True
        Me.btnDineIn.Size = New System.Drawing.Size(350, 450)
        Me.btnDineIn.TabIndex = 0
        Me.btnDineIn.Text = "Dine In"
        Me.btnDineIn.TextOffset = New System.Drawing.Point(-50, 110)
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.btnCategoriesBack)
        Me.pnlCategories.Controls.Add(Me.flpCategories)
        Me.pnlCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCategories.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(753, 528)
        Me.pnlCategories.TabIndex = 3
        '
        'btnCategoriesBack
        '
        Me.btnCategoriesBack.BackColor = System.Drawing.Color.Transparent
        Me.btnCategoriesBack.BorderRadius = 15
        Me.btnCategoriesBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCategoriesBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCategoriesBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCategoriesBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCategoriesBack.FillColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnCategoriesBack.Font = New System.Drawing.Font("Segoe UI Variable Small", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategoriesBack.ForeColor = System.Drawing.Color.Black
        Me.btnCategoriesBack.Location = New System.Drawing.Point(1208, 12)
        Me.btnCategoriesBack.Name = "btnCategoriesBack"
        Me.btnCategoriesBack.ShadowDecoration.BorderRadius = 20
        Me.btnCategoriesBack.ShadowDecoration.Enabled = True
        Me.btnCategoriesBack.Size = New System.Drawing.Size(130, 35)
        Me.btnCategoriesBack.TabIndex = 0
        Me.btnCategoriesBack.Text = "Back"
        '
        'flpCategories
        '
        Me.flpCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpCategories.Location = New System.Drawing.Point(0, 0)
        Me.flpCategories.Name = "flpCategories"
        Me.flpCategories.Padding = New System.Windows.Forms.Padding(12)
        Me.flpCategories.Size = New System.Drawing.Size(753, 528)
        Me.flpCategories.TabIndex = 0
        '
        'pnlProducts
        '
        Me.pnlProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.pnlProducts.Controls.Add(Me.btnProductsBack)
        Me.pnlProducts.Controls.Add(Me.flpProducts)
        Me.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProducts.Location = New System.Drawing.Point(0, 0)
        Me.pnlProducts.Name = "pnlProducts"
        Me.pnlProducts.Size = New System.Drawing.Size(753, 528)
        Me.pnlProducts.TabIndex = 1
        '
        'btnProductsBack
        '
        Me.btnProductsBack.BackColor = System.Drawing.Color.Transparent
        Me.btnProductsBack.BorderRadius = 15
        Me.btnProductsBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnProductsBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnProductsBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnProductsBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnProductsBack.FillColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnProductsBack.Font = New System.Drawing.Font("Segoe UI Variable Small", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductsBack.ForeColor = System.Drawing.Color.Black
        Me.btnProductsBack.Location = New System.Drawing.Point(1208, 12)
        Me.btnProductsBack.Name = "btnProductsBack"
        Me.btnProductsBack.ShadowDecoration.BorderRadius = 20
        Me.btnProductsBack.ShadowDecoration.Enabled = True
        Me.btnProductsBack.Size = New System.Drawing.Size(130, 35)
        Me.btnProductsBack.TabIndex = 1
        Me.btnProductsBack.Text = "Back"
        '
        'flpProducts
        '
        Me.flpProducts.AutoScroll = True
        Me.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpProducts.Location = New System.Drawing.Point(0, 0)
        Me.flpProducts.Name = "flpProducts"
        Me.flpProducts.Padding = New System.Windows.Forms.Padding(12)
        Me.flpProducts.Size = New System.Drawing.Size(753, 528)
        Me.flpProducts.TabIndex = 0
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.lblAdCaption)
        Me.pnlTop.Controls.Add(Me.picAds)
        Me.pnlTop.Controls.Add(Me.lblTime)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1113, 106)
        Me.pnlTop.TabIndex = 0
        Me.pnlTop.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Great Coffee, Great Mood"
        '
        'lblAdCaption
        '
        Me.lblAdCaption.AutoSize = True
        Me.lblAdCaption.BackColor = System.Drawing.Color.Black
        Me.lblAdCaption.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdCaption.ForeColor = System.Drawing.Color.White
        Me.lblAdCaption.Location = New System.Drawing.Point(12, 20)
        Me.lblAdCaption.Name = "lblAdCaption"
        Me.lblAdCaption.Size = New System.Drawing.Size(167, 45)
        Me.lblAdCaption.TabIndex = 2
        Me.lblAdCaption.Text = "Welcome," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'picAds
        '
        Me.picAds.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.picAds.Dock = System.Windows.Forms.DockStyle.Left
        Me.picAds.Location = New System.Drawing.Point(0, 0)
        Me.picAds.Name = "picAds"
        Me.picAds.Padding = New System.Windows.Forms.Padding(12)
        Me.picAds.Size = New System.Drawing.Size(900, 106)
        Me.picAds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAds.TabIndex = 0
        Me.picAds.TabStop = False
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTime.Location = New System.Drawing.Point(904, 46)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(463, 40)
        Me.lblTime.TabIndex = 1
        Me.lblTime.Text = "Label1"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.Tan
        Me.pnlMain.Controls.Add(Me.pnlCategories)
        Me.pnlMain.Controls.Add(Me.pnlProducts)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 106)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(753, 528)
        Me.pnlMain.TabIndex = 0
        '
        'pnlCartTray
        '
        Me.pnlCartTray.BackColor = System.Drawing.Color.FloralWhite
        Me.pnlCartTray.Controls.Add(Me.btnViewCart)
        Me.pnlCartTray.Controls.Add(Me.lblCartTotal)
        Me.pnlCartTray.Controls.Add(Me.lblCartCount)
        Me.pnlCartTray.Controls.Add(Me.lblRecentItem)
        Me.pnlCartTray.Controls.Add(Me.lblCartTitle)
        Me.pnlCartTray.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCartTray.Location = New System.Drawing.Point(753, 106)
        Me.pnlCartTray.Name = "pnlCartTray"
        Me.pnlCartTray.Size = New System.Drawing.Size(360, 528)
        Me.pnlCartTray.TabIndex = 0
        Me.pnlCartTray.Visible = False
        '
        'btnViewCart
        '
        Me.btnViewCart.BackColor = System.Drawing.Color.Transparent
        Me.btnViewCart.BorderRadius = 10
        Me.btnViewCart.BorderThickness = 1
        Me.btnViewCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnViewCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnViewCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnViewCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnViewCart.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnViewCart.FillColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnViewCart.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewCart.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnViewCart.Location = New System.Drawing.Point(0, 478)
        Me.btnViewCart.Name = "btnViewCart"
        Me.btnViewCart.ShadowDecoration.BorderRadius = 10
        Me.btnViewCart.ShadowDecoration.Depth = 70
        Me.btnViewCart.ShadowDecoration.Enabled = True
        Me.btnViewCart.Size = New System.Drawing.Size(360, 50)
        Me.btnViewCart.TabIndex = 4
        Me.btnViewCart.Text = "VIEW CART"
        '
        'lblCartTotal
        '
        Me.lblCartTotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCartTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCartTotal.Location = New System.Drawing.Point(0, 106)
        Me.lblCartTotal.Name = "lblCartTotal"
        Me.lblCartTotal.Padding = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblCartTotal.Size = New System.Drawing.Size(360, 35)
        Me.lblCartTotal.TabIndex = 3
        Me.lblCartTotal.Text = "TOTAL: ₱ 0.00"
        Me.lblCartTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCartCount
        '
        Me.lblCartCount.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCartCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartCount.Location = New System.Drawing.Point(0, 71)
        Me.lblCartCount.Name = "lblCartCount"
        Me.lblCartCount.Padding = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblCartCount.Size = New System.Drawing.Size(360, 35)
        Me.lblCartCount.TabIndex = 2
        Me.lblCartCount.Text = "Items: 0"
        Me.lblCartCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecentItem
        '
        Me.lblRecentItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRecentItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecentItem.Location = New System.Drawing.Point(0, 36)
        Me.lblRecentItem.Name = "lblRecentItem"
        Me.lblRecentItem.Padding = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblRecentItem.Size = New System.Drawing.Size(360, 35)
        Me.lblRecentItem.TabIndex = 1
        Me.lblRecentItem.Text = "Your tray is empty!"
        Me.lblRecentItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCartTitle
        '
        Me.lblCartTitle.BackColor = System.Drawing.SystemColors.InfoText
        Me.lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCartTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartTitle.ForeColor = System.Drawing.Color.FloralWhite
        Me.lblCartTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblCartTitle.Name = "lblCartTitle"
        Me.lblCartTitle.Size = New System.Drawing.Size(360, 36)
        Me.lblCartTitle.TabIndex = 0
        Me.lblCartTitle.Text = "My Order"
        Me.lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCart
        '
        Me.pnlCart.BackColor = System.Drawing.Color.FloralWhite
        Me.pnlCart.Controls.Add(Me.pnlCartFooter)
        Me.pnlCart.Controls.Add(Me.flpCartItems)
        Me.pnlCart.Controls.Add(Me.lblCartHeader)
        Me.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCart.Location = New System.Drawing.Point(0, 106)
        Me.pnlCart.Name = "pnlCart"
        Me.pnlCart.Size = New System.Drawing.Size(1113, 528)
        Me.pnlCart.TabIndex = 0
        '
        'pnlCartFooter
        '
        Me.pnlCartFooter.Controls.Add(Me.btnCancelCart)
        Me.pnlCartFooter.Controls.Add(Me.btnCheckout)
        Me.pnlCartFooter.Controls.Add(Me.lblCartFooterTotal)
        Me.pnlCartFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCartFooter.Location = New System.Drawing.Point(0, 448)
        Me.pnlCartFooter.Name = "pnlCartFooter"
        Me.pnlCartFooter.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlCartFooter.Size = New System.Drawing.Size(1113, 80)
        Me.pnlCartFooter.TabIndex = 3
        '
        'btnCancelCart
        '
        Me.btnCancelCart.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelCart.BorderRadius = 15
        Me.btnCancelCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancelCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancelCart.FillColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnCancelCart.Font = New System.Drawing.Font("Segoe UI Variable Small", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelCart.ForeColor = System.Drawing.Color.Black
        Me.btnCancelCart.Location = New System.Drawing.Point(721, 23)
        Me.btnCancelCart.Name = "btnCancelCart"
        Me.btnCancelCart.ShadowDecoration.BorderRadius = 20
        Me.btnCancelCart.ShadowDecoration.Enabled = True
        Me.btnCancelCart.Size = New System.Drawing.Size(130, 35)
        Me.btnCancelCart.TabIndex = 3
        Me.btnCancelCart.Text = "Cancel"
        '
        'btnCheckout
        '
        Me.btnCheckout.BackColor = System.Drawing.Color.Transparent
        Me.btnCheckout.BorderRadius = 15
        Me.btnCheckout.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCheckout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCheckout.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCheckout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCheckout.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnCheckout.Font = New System.Drawing.Font("Segoe UI Variable Small", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.ForeColor = System.Drawing.Color.Black
        Me.btnCheckout.Location = New System.Drawing.Point(499, 23)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.ShadowDecoration.BorderRadius = 20
        Me.btnCheckout.ShadowDecoration.Enabled = True
        Me.btnCheckout.Size = New System.Drawing.Size(130, 35)
        Me.btnCheckout.TabIndex = 2
        Me.btnCheckout.Text = "CHECKOUT"
        '
        'lblCartFooterTotal
        '
        Me.lblCartFooterTotal.AutoSize = True
        Me.lblCartFooterTotal.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartFooterTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCartFooterTotal.Location = New System.Drawing.Point(1111, 20)
        Me.lblCartFooterTotal.Name = "lblCartFooterTotal"
        Me.lblCartFooterTotal.Size = New System.Drawing.Size(191, 37)
        Me.lblCartFooterTotal.TabIndex = 0
        Me.lblCartFooterTotal.Text = "TOTAL: ₱ 0.00"
        '
        'flpCartItems
        '
        Me.flpCartItems.AutoScroll = True
        Me.flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCartItems.Location = New System.Drawing.Point(0, 50)
        Me.flpCartItems.Name = "flpCartItems"
        Me.flpCartItems.Padding = New System.Windows.Forms.Padding(8)
        Me.flpCartItems.Size = New System.Drawing.Size(1113, 478)
        Me.flpCartItems.TabIndex = 2
        Me.flpCartItems.WrapContents = False
        '
        'lblCartHeader
        '
        Me.lblCartHeader.BackColor = System.Drawing.SystemColors.InfoText
        Me.lblCartHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCartHeader.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartHeader.ForeColor = System.Drawing.Color.FloralWhite
        Me.lblCartHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblCartHeader.Name = "lblCartHeader"
        Me.lblCartHeader.Size = New System.Drawing.Size(1113, 50)
        Me.lblCartHeader.TabIndex = 0
        Me.lblCartHeader.Text = "Your Cart"
        Me.lblCartHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCustomization
        '
        Me.pnlCustomization.BackColor = System.Drawing.Color.FloralWhite
        Me.pnlCustomization.Controls.Add(Me.btnCustomizationBack)
        Me.pnlCustomization.Controls.Add(Me.btnAddToCart)
        Me.pnlCustomization.Controls.Add(Me.flpAddOns)
        Me.pnlCustomization.Controls.Add(Me.lblmilk)
        Me.pnlCustomization.Controls.Add(Me.lblsugar)
        Me.pnlCustomization.Controls.Add(Me.lblcoffee)
        Me.pnlCustomization.Controls.Add(Me.cmbMilk)
        Me.pnlCustomization.Controls.Add(Me.cmbCoffee)
        Me.pnlCustomization.Controls.Add(Me.cmbSugar)
        Me.pnlCustomization.Controls.Add(Me.cmbSize)
        Me.pnlCustomization.Controls.Add(Me.nudQuantity)
        Me.pnlCustomization.Controls.Add(Me.lblCustomPrice)
        Me.pnlCustomization.Controls.Add(Me.lblsize)
        Me.pnlCustomization.Controls.Add(Me.lblProductName)
        Me.pnlCustomization.Controls.Add(Me.picProduct)
        Me.pnlCustomization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCustomization.Location = New System.Drawing.Point(0, 0)
        Me.pnlCustomization.Name = "pnlCustomization"
        Me.pnlCustomization.Size = New System.Drawing.Size(1113, 634)
        Me.pnlCustomization.TabIndex = 0
        Me.pnlCustomization.Visible = False
        '
        'btnCustomizationBack
        '
        Me.btnCustomizationBack.BackColor = System.Drawing.Color.Transparent
        Me.btnCustomizationBack.BorderRadius = 15
        Me.btnCustomizationBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCustomizationBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCustomizationBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCustomizationBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCustomizationBack.FillColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnCustomizationBack.Font = New System.Drawing.Font("Segoe UI Variable Small", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomizationBack.ForeColor = System.Drawing.Color.Black
        Me.btnCustomizationBack.Location = New System.Drawing.Point(1159, 631)
        Me.btnCustomizationBack.Name = "btnCustomizationBack"
        Me.btnCustomizationBack.ShadowDecoration.BorderRadius = 20
        Me.btnCustomizationBack.ShadowDecoration.Enabled = True
        Me.btnCustomizationBack.Size = New System.Drawing.Size(130, 35)
        Me.btnCustomizationBack.TabIndex = 10
        Me.btnCustomizationBack.Text = "Back"
        '
        'btnAddToCart
        '
        Me.btnAddToCart.BackColor = System.Drawing.Color.Transparent
        Me.btnAddToCart.BorderRadius = 15
        Me.btnAddToCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnAddToCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnAddToCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAddToCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnAddToCart.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnAddToCart.Font = New System.Drawing.Font("Segoe UI Variable Small", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCart.ForeColor = System.Drawing.Color.Black
        Me.btnAddToCart.Location = New System.Drawing.Point(610, 631)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.ShadowDecoration.BorderRadius = 20
        Me.btnAddToCart.ShadowDecoration.Enabled = True
        Me.btnAddToCart.Size = New System.Drawing.Size(130, 35)
        Me.btnAddToCart.TabIndex = 9
        Me.btnAddToCart.Text = "Add To Cart"
        '
        'flpAddOns
        '
        Me.flpAddOns.AutoScroll = True
        Me.flpAddOns.Location = New System.Drawing.Point(589, 35)
        Me.flpAddOns.Name = "flpAddOns"
        Me.flpAddOns.Size = New System.Drawing.Size(700, 250)
        Me.flpAddOns.TabIndex = 8
        '
        'lblmilk
        '
        Me.lblmilk.AutoSize = True
        Me.lblmilk.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmilk.Location = New System.Drawing.Point(1089, 411)
        Me.lblmilk.Name = "lblmilk"
        Me.lblmilk.Size = New System.Drawing.Size(57, 25)
        Me.lblmilk.TabIndex = 7
        Me.lblmilk.Text = "Milk:"
        '
        'lblsugar
        '
        Me.lblsugar.AutoSize = True
        Me.lblsugar.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsugar.Location = New System.Drawing.Point(727, 411)
        Me.lblsugar.Name = "lblsugar"
        Me.lblsugar.Size = New System.Drawing.Size(115, 25)
        Me.lblsugar.TabIndex = 6
        Me.lblsugar.Text = "Sugar level:"
        '
        'lblcoffee
        '
        Me.lblcoffee.AutoSize = True
        Me.lblcoffee.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcoffee.Location = New System.Drawing.Point(360, 411)
        Me.lblcoffee.Name = "lblcoffee"
        Me.lblcoffee.Size = New System.Drawing.Size(120, 25)
        Me.lblcoffee.TabIndex = 5
        Me.lblcoffee.Text = "Coffee level:"
        '
        'cmbMilk
        '
        Me.cmbMilk.BackColor = System.Drawing.Color.Transparent
        Me.cmbMilk.BorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.cmbMilk.BorderRadius = 5
        Me.cmbMilk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMilk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMilk.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cmbMilk.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbMilk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbMilk.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbMilk.ForeColor = System.Drawing.Color.Black
        Me.cmbMilk.IntegralHeight = False
        Me.cmbMilk.ItemHeight = 30
        Me.cmbMilk.Items.AddRange(New Object() {"None", "Whole", "Skim", "Soy", "Oat"})
        Me.cmbMilk.Location = New System.Drawing.Point(1149, 400)
        Me.cmbMilk.Name = "cmbMilk"
        Me.cmbMilk.Size = New System.Drawing.Size(140, 36)
        Me.cmbMilk.TabIndex = 4
        '
        'cmbCoffee
        '
        Me.cmbCoffee.BackColor = System.Drawing.Color.Transparent
        Me.cmbCoffee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.cmbCoffee.BorderRadius = 5
        Me.cmbCoffee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCoffee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoffee.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cmbCoffee.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCoffee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbCoffee.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbCoffee.ForeColor = System.Drawing.Color.Black
        Me.cmbCoffee.IntegralHeight = False
        Me.cmbCoffee.ItemHeight = 30
        Me.cmbCoffee.Items.AddRange(New Object() {"Light", "Regular", "Strong"})
        Me.cmbCoffee.Location = New System.Drawing.Point(486, 400)
        Me.cmbCoffee.Name = "cmbCoffee"
        Me.cmbCoffee.Size = New System.Drawing.Size(140, 36)
        Me.cmbCoffee.TabIndex = 4
        '
        'cmbSugar
        '
        Me.cmbSugar.BackColor = System.Drawing.Color.Transparent
        Me.cmbSugar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.cmbSugar.BorderRadius = 5
        Me.cmbSugar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSugar.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cmbSugar.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSugar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSugar.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbSugar.ForeColor = System.Drawing.Color.Black
        Me.cmbSugar.IntegralHeight = False
        Me.cmbSugar.ItemHeight = 30
        Me.cmbSugar.Items.AddRange(New Object() {"0%", "25%", "50%", "75%", "100%"})
        Me.cmbSugar.Location = New System.Drawing.Point(848, 400)
        Me.cmbSugar.Name = "cmbSugar"
        Me.cmbSugar.Size = New System.Drawing.Size(140, 36)
        Me.cmbSugar.TabIndex = 4
        '
        'cmbSize
        '
        Me.cmbSize.BackColor = System.Drawing.Color.Transparent
        Me.cmbSize.BorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.cmbSize.BorderRadius = 5
        Me.cmbSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSize.FillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.cmbSize.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSize.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbSize.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbSize.ForeColor = System.Drawing.Color.Black
        Me.cmbSize.IntegralHeight = False
        Me.cmbSize.ItemHeight = 30
        Me.cmbSize.Items.AddRange(New Object() {"Small", "Regular", "Large"})
        Me.cmbSize.Location = New System.Drawing.Point(119, 400)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(140, 36)
        Me.cmbSize.TabIndex = 4
        '
        'nudQuantity
        '
        Me.nudQuantity.BackColor = System.Drawing.Color.Transparent
        Me.nudQuantity.BorderColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.nudQuantity.BorderRadius = 5
        Me.nudQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudQuantity.FillColor = System.Drawing.Color.FloralWhite
        Me.nudQuantity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudQuantity.Location = New System.Drawing.Point(349, 298)
        Me.nudQuantity.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(117, 46)
        Me.nudQuantity.TabIndex = 3
        Me.nudQuantity.UpDownButtonFillColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCustomPrice
        '
        Me.lblCustomPrice.AutoSize = True
        Me.lblCustomPrice.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomPrice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCustomPrice.Location = New System.Drawing.Point(62, 323)
        Me.lblCustomPrice.Name = "lblCustomPrice"
        Me.lblCustomPrice.Size = New System.Drawing.Size(60, 21)
        Me.lblCustomPrice.TabIndex = 2
        Me.lblCustomPrice.Text = "Label1"
        '
        'lblsize
        '
        Me.lblsize.AutoSize = True
        Me.lblsize.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsize.Location = New System.Drawing.Point(61, 411)
        Me.lblsize.Name = "lblsize"
        Me.lblsize.Size = New System.Drawing.Size(52, 25)
        Me.lblsize.TabIndex = 1
        Me.lblsize.Text = "Size:"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(61, 298)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(70, 25)
        Me.lblProductName.TabIndex = 1
        Me.lblProductName.Text = "Label1"
        '
        'picProduct
        '
        Me.picProduct.Location = New System.Drawing.Point(66, 35)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(400, 250)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 0
        Me.picProduct.TabStop = False
        '
        'TimerClock
        '
        '
        'frmKiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 634)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlCartTray)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.pnlCart)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlCustomization)
        Me.Controls.Add(Me.pnlOrderStart)
        Me.Controls.Add(Me.pnlIdle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKiosk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlIdle.ResumeLayout(False)
        CType(Me.picIdle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOrderStart.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlProducts.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.picAds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlCartTray.ResumeLayout(False)
        Me.pnlCart.ResumeLayout(False)
        Me.pnlCartFooter.ResumeLayout(False)
        Me.pnlCartFooter.PerformLayout()
        Me.pnlCustomization.ResumeLayout(False)
        Me.pnlCustomization.PerformLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnTestConnection As Button
    Friend WithEvents pnlIdle As Panel
    Friend WithEvents picIdle As PictureBox
    Friend WithEvents lblIdleInfo As Label
    Friend WithEvents TimerAds As Timer
    Friend WithEvents pnlOrderStart As Panel
    Friend WithEvents pnlCategories As Panel
    Friend WithEvents btnDineIn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnTakeOut As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents flpCategories As FlowLayoutPanel
    Friend WithEvents btnCategoriesBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlProducts As Panel
    Friend WithEvents flpProducts As FlowLayoutPanel
    Friend WithEvents btnProductsBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlTop As Panel
    Friend WithEvents picAds As PictureBox
    Friend WithEvents lblTime As Label
    Friend WithEvents lblAdCaption As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlCartTray As Panel
    Friend WithEvents lblRecentItem As Label
    Friend WithEvents lblCartTitle As Label
    Friend WithEvents lblCartTotal As Label
    Friend WithEvents lblCartCount As Label
    Friend WithEvents btnViewCart As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlCart As Panel
    Friend WithEvents lblCartHeader As Label
    Friend WithEvents pnlCartFooter As Panel
    Friend WithEvents flpCartItems As FlowLayoutPanel
    Friend WithEvents lblCartFooterTotal As Label
    Friend WithEvents btnCheckout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancelCart As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlCustomization As Panel
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents lblCustomPrice As Label
    Friend WithEvents lblProductName As Label
    Friend WithEvents nudQuantity As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents cmbSize As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbSugar As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblcoffee As Label
    Friend WithEvents cmbMilk As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cmbCoffee As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblsize As Label
    Friend WithEvents lblmilk As Label
    Friend WithEvents lblsugar As Label
    Friend WithEvents flpAddOns As FlowLayoutPanel
    Friend WithEvents btnAddToCart As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCustomizationBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents TimerClock As Timer
    Friend WithEvents Label1 As Label
End Class
