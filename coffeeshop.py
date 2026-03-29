"""Coffee Shop Order Management System."""

from enum import Enum
from dataclasses import dataclass, field
from typing import Optional
import uuid


class OrderStatus(Enum):
    PENDING = "pending"
    ACCEPTED = "accepted"
    REJECTED = "rejected"
    COMPLETED = "completed"


MENU = {
    "espresso": 2.50,
    "americano": 3.00,
    "latte": 4.00,
    "cappuccino": 4.00,
    "mocha": 4.50,
    "cold brew": 5.00,
    "tea": 2.00,
}


@dataclass
class OrderItem:
    item: str
    quantity: int
    price: float

    @property
    def subtotal(self) -> float:
        return self.price * self.quantity


@dataclass
class Order:
    customer_name: str
    items: list[OrderItem] = field(default_factory=list)
    order_id: str = field(default_factory=lambda: str(uuid.uuid4())[:8])
    status: OrderStatus = OrderStatus.PENDING
    notes: str = ""

    @property
    def total(self) -> float:
        return sum(item.subtotal for item in self.items)

    def __str__(self) -> str:
        lines = [
            f"Order #{self.order_id} for {self.customer_name} [{self.status.value.upper()}]",
        ]
        for item in self.items:
            lines.append(f"  - {item.item} x{item.quantity} @ ${item.price:.2f} = ${item.subtotal:.2f}")
        lines.append(f"  Total: ${self.total:.2f}")
        if self.notes:
            lines.append(f"  Notes: {self.notes}")
        return "\n".join(lines)


class CoffeeShop:
    def __init__(self, name: str = "The Coffee Shop"):
        self.name = name
        self.orders: dict[str, Order] = {}

    def show_menu(self) -> None:
        print(f"\n=== {self.name} Menu ===")
        for item, price in MENU.items():
            print(f"  {item.title():<20} ${price:.2f}")
        print()

    def place_order(self, customer_name: str, items: list[tuple[str, int]], notes: str = "") -> Order:
        """Place a new order (submit a pull request for coffee items)."""
        order_items = []
        for item_name, quantity in items:
            item_name_lower = item_name.lower()
            if item_name_lower not in MENU:
                raise ValueError(f"'{item_name}' is not on the menu.")
            if quantity <= 0:
                raise ValueError(f"Quantity for '{item_name}' must be positive.")
            order_items.append(OrderItem(item=item_name_lower, quantity=quantity, price=MENU[item_name_lower]))

        order = Order(customer_name=customer_name, items=order_items, notes=notes)
        self.orders[order.order_id] = order
        print(f"\nOrder placed! Your order ID is #{order.order_id}")
        return order

    def accept_order(self, order_id: str) -> Order:
        """Accept a pending order."""
        order = self._get_order(order_id)
        if order.status != OrderStatus.PENDING:
            raise ValueError(f"Order #{order_id} cannot be accepted (status: {order.status.value}).")
        order.status = OrderStatus.ACCEPTED
        print(f"Order #{order_id} has been accepted!")
        return order

    def reject_order(self, order_id: str, reason: str = "") -> Order:
        """Reject a pending order."""
        order = self._get_order(order_id)
        if order.status != OrderStatus.PENDING:
            raise ValueError(f"Order #{order_id} cannot be rejected (status: {order.status.value}).")
        order.status = OrderStatus.REJECTED
        msg = f"Order #{order_id} has been rejected."
        if reason:
            msg += f" Reason: {reason}"
        print(msg)
        return order

    def complete_order(self, order_id: str) -> Order:
        """Mark an accepted order as completed."""
        order = self._get_order(order_id)
        if order.status != OrderStatus.ACCEPTED:
            raise ValueError(f"Order #{order_id} cannot be completed (status: {order.status.value}).")
        order.status = OrderStatus.COMPLETED
        print(f"Order #{order_id} is ready for {order.customer_name}!")
        return order

    def list_pending_orders(self) -> list[Order]:
        """List all pending orders awaiting acceptance."""
        return [o for o in self.orders.values() if o.status == OrderStatus.PENDING]

    def list_orders(self, status: Optional[OrderStatus] = None) -> list[Order]:
        """List orders, optionally filtered by status."""
        if status:
            return [o for o in self.orders.values() if o.status == status]
        return list(self.orders.values())

    def print_orders(self, status: Optional[OrderStatus] = None) -> None:
        orders = self.list_orders(status)
        if not orders:
            label = f" {status.value}" if status else ""
            print(f"No{label} orders.")
            return
        for order in orders:
            print(order)
            print()

    def _get_order(self, order_id: str) -> Order:
        if order_id not in self.orders:
            raise KeyError(f"Order #{order_id} not found.")
        return self.orders[order_id]


def main() -> None:
    shop = CoffeeShop("Rainnn's Coffee Shop")
    shop.show_menu()

    # Customers place orders
    order1 = shop.place_order("Alice", [("latte", 1), ("espresso", 2)], notes="Extra hot")
    order2 = shop.place_order("Bob", [("cold brew", 1), ("mocha", 1)])
    order3 = shop.place_order("Carol", [("americano", 2)])

    print("\n--- Pending Orders ---")
    shop.print_orders(OrderStatus.PENDING)

    # Barista accepts orders
    shop.accept_order(order1.order_id)
    shop.accept_order(order2.order_id)

    # One order is rejected (e.g. out of stock)
    shop.reject_order(order3.order_id, reason="Americano machine is down")

    print("\n--- All Orders ---")
    shop.print_orders()

    # Complete accepted orders
    shop.complete_order(order1.order_id)
    shop.complete_order(order2.order_id)

    print("\n--- Completed Orders ---")
    shop.print_orders(OrderStatus.COMPLETED)


if __name__ == "__main__":
    main()
