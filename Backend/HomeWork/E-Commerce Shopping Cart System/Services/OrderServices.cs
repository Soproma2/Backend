using E_Commerce_Shopping_Cart_System.Enums;
using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class OrderServices
    {
        public static string path = "Data/Orders.json";
        public static List<Order> Orders = JsonHelper.LoadData<Order>(path);
        public static void Checkout(User user)
        {
            var cart = CartServices.CartItems.Where(c => c.UserId == user.UserId).ToList();
            if (cart.Count == 0) { Console.WriteLine("Cart empty!"); return; }

            double total = 0;
            foreach (var c in cart)
            {
                var p = ProductServices.Products.FirstOrDefault(x => x.ProductId == c.ProductId);
                if (p != null) total += p.Price * c.Quantity;
            }

            if (user.Balance < total) { Console.WriteLine("Insufficient balance!"); return; }
            user.Balance -= total;
            JsonHelper.SaveData(UserServices.path, UserServices.Users);

            int oid = Orders.Count > 0 ? Orders.Max(o => o.OrderId) + 1 : 1;
            var order = new Order { OrderId = oid, UserId = user.UserId, OrderDate = DateTime.Now, TotalPrice = total };
            foreach (var c in cart)
            {
                var p = ProductServices.Products.FirstOrDefault(x => x.ProductId == c.ProductId);
                if (p != null)
                {
                    order.Items.Add(new OrderItem { ProductId = p.ProductId, Quantity = c.Quantity, Price = p.Price });
                    p.Stock -= c.Quantity;
                }
            }
            Orders.Add(order);
            JsonHelper.SaveData(path, Orders);
            JsonHelper.SaveData(ProductServices.path, ProductServices.Products);

            CartServices.CartItems.RemoveAll(c => c.UserId == user.UserId);
            JsonHelper.SaveData(CartServices.path, CartServices.CartItems);
            Console.WriteLine("Checkout successful!");
        }

        public static void ViewOrderHistory(User user)
        {
            var userOrders = Orders.Where(o => o.UserId == user.UserId).ToList();
            if (userOrders.Count == 0) { Console.WriteLine("No orders!"); return; }
            foreach (var o in userOrders)
            {
                Console.WriteLine($"Order #{o.OrderId} - {o.OrderDate} - Total: {o.TotalPrice}$ - Status: {o.Status}");
                foreach (var item in o.Items)
                {
                    var p = ProductServices.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
                    if (p != null) Console.WriteLine($"  {p.Name} x {item.Quantity} = {item.Price * item.Quantity}$");
                }
            }
        }

        public static void CancelOrder(User user)
        {
            ViewOrderHistory(user);
            Console.Write("Enter Order ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int oId)) { Console.WriteLine("Invalid ID!"); return; }
            var order = Orders.FirstOrDefault(o => o.OrderId == oId && o.UserId == user.UserId);
            if (order == null) { Console.WriteLine("Order not found!"); return; }
            if (order.Status != OrderStatus.PENDING) { Console.WriteLine("Cannot cancel!"); return; }

            order.Status = OrderStatus.CANCELLED;
            user.Balance += order.TotalPrice;
            JsonHelper.SaveData(path, Orders);
            JsonHelper.SaveData(UserServices.path, UserServices.Users);
            Console.WriteLine("Order cancelled!");
        }

        public static void ViewAllOrders()
        {
            Console.WriteLine("\n===== ALL ORDERS =====");
            foreach (var o in Orders)
            {
                var u = UserServices.Users.FirstOrDefault(x => x.UserId == o.UserId);
                Console.WriteLine($"Order #{o.OrderId} by {u?.Username} - {o.TotalPrice}$ - {o.Status}");
            }
        }

        public static void MarkOrderDelivered()
        {
            Console.WriteLine("===== ALL ORDERS =====");
            ViewAllOrders();

            Console.Write("\nEnter Order ID to mark as DELIVERED: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found!");
                return;
            }

            if (order.Status == OrderStatus.CANCELLED)
            {
                Console.WriteLine("Cannot deliver a cancelled order!");
                return;
            }

            if (order.Status == OrderStatus.DELIVERED)
            {
                Console.WriteLine("Order already delivered!");
                return;
            }

            order.Status = OrderStatus.DELIVERED;
            JsonHelper.SaveData(path, Orders);
            Console.WriteLine($"Order #{orderId} marked as DELIVERED successfully.");
        }

        public static void AdminCancelOrder()
        {
            Console.WriteLine("===== ALL ORDERS =====");
            ViewAllOrders();

            Console.Write("\nEnter Order ID to CANCEL: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found!");
                return;
            }

            if (order.Status == OrderStatus.CANCELLED)
            {
                Console.WriteLine("Order already cancelled!");
                return;
            }

            if (order.Status == OrderStatus.DELIVERED)
            {
                Console.WriteLine("Cannot cancel a delivered order!");
                return;
            }

            order.Status = OrderStatus.CANCELLED;

            var user = UserServices.Users.FirstOrDefault(x => x.UserId == order.UserId);
            if (user != null)
            {
                user.Balance += order.TotalPrice;
                JsonHelper.SaveData(UserServices.path, UserServices.Users);
            }

            JsonHelper.SaveData(path, Orders);
            Console.WriteLine($"Order #{orderId} cancelled by admin.");
        }
    }
}
