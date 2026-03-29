"""Tests for the Coffee Shop Order Management System."""

import pytest
from coffeeshop import CoffeeShop, Order, OrderStatus, MENU


@pytest.fixture
def shop():
    return CoffeeShop("Test Coffee Shop")


def test_show_menu(shop, capsys):
    shop.show_menu()
    captured = capsys.readouterr()
    assert "Test Coffee Shop Menu" in captured.out
    assert "Espresso" in captured.out
    assert "Latte" in captured.out


def test_place_order(shop):
    order = shop.place_order("Alice", [("latte", 1), ("espresso", 2)])
    assert order.customer_name == "Alice"
    assert len(order.items) == 2
    assert order.status == OrderStatus.PENDING
    assert order.total == MENU["latte"] * 1 + MENU["espresso"] * 2


def test_place_order_with_notes(shop):
    order = shop.place_order("Bob", [("mocha", 1)], notes="Extra sugar")
    assert order.notes == "Extra sugar"


def test_place_order_invalid_item(shop):
    with pytest.raises(ValueError, match="not on the menu"):
        shop.place_order("Alice", [("pizza", 1)])


def test_place_order_invalid_quantity(shop):
    with pytest.raises(ValueError, match="must be positive"):
        shop.place_order("Alice", [("latte", 0)])


def test_accept_order(shop):
    order = shop.place_order("Alice", [("latte", 1)])
    accepted = shop.accept_order(order.order_id)
    assert accepted.status == OrderStatus.ACCEPTED


def test_accept_order_not_found(shop):
    with pytest.raises(KeyError):
        shop.accept_order("nonexistent")


def test_accept_already_accepted_order(shop):
    order = shop.place_order("Alice", [("latte", 1)])
    shop.accept_order(order.order_id)
    with pytest.raises(ValueError, match="cannot be accepted"):
        shop.accept_order(order.order_id)


def test_reject_order(shop):
    order = shop.place_order("Bob", [("americano", 1)])
    rejected = shop.reject_order(order.order_id, reason="Out of stock")
    assert rejected.status == OrderStatus.REJECTED


def test_reject_already_rejected_order(shop):
    order = shop.place_order("Bob", [("americano", 1)])
    shop.reject_order(order.order_id)
    with pytest.raises(ValueError, match="cannot be rejected"):
        shop.reject_order(order.order_id)


def test_complete_order(shop):
    order = shop.place_order("Carol", [("cappuccino", 1)])
    shop.accept_order(order.order_id)
    completed = shop.complete_order(order.order_id)
    assert completed.status == OrderStatus.COMPLETED


def test_complete_pending_order_raises(shop):
    order = shop.place_order("Carol", [("cappuccino", 1)])
    with pytest.raises(ValueError, match="cannot be completed"):
        shop.complete_order(order.order_id)


def test_list_pending_orders(shop):
    order1 = shop.place_order("Alice", [("latte", 1)])
    order2 = shop.place_order("Bob", [("mocha", 1)])
    shop.accept_order(order1.order_id)

    pending = shop.list_pending_orders()
    assert len(pending) == 1
    assert pending[0].order_id == order2.order_id


def test_list_orders_filtered(shop):
    order1 = shop.place_order("Alice", [("latte", 1)])
    order2 = shop.place_order("Bob", [("mocha", 1)])
    shop.accept_order(order1.order_id)

    accepted = shop.list_orders(OrderStatus.ACCEPTED)
    assert len(accepted) == 1
    assert accepted[0].order_id == order1.order_id


def test_order_str(shop):
    order = shop.place_order("Alice", [("latte", 2)])
    result = str(order)
    assert "Alice" in result
    assert "latte" in result
    assert "PENDING" in result


def test_order_total(shop):
    order = shop.place_order("Dave", [("espresso", 2), ("tea", 3)])
    expected = MENU["espresso"] * 2 + MENU["tea"] * 3
    assert order.total == pytest.approx(expected)
