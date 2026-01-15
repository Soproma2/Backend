using Entity_Project.Data;
using Entity_Project.Enums;
using Entity_Project.Services.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Order
{
    internal class OrderService : IOrderService
    {
        private readonly DataContext _db = new DataContext();
        public void Checkout(Models.User user)
        {
            if (user == null) throw new Exception("Unauthorized!");

            var cartItems = _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!cartItems.Any()) throw new Exception("Your cart is empty!");

            double totalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity);

            var dbUser = _db.Users.Find(user.Id);
            if (dbUser.Balance < totalPrice)
                throw new Exception($"Insufficient balance! Needed: {totalPrice}$, Available: {user.Balance}$");

            foreach (var item in cartItems)
            {
                if (item.Product.Stock < item.Quantity)
                    throw new Exception($"Product {item.Product.Name}. Insufficient quantity in stock | Stock: {item.Product.Stock}");
            }

            Models.Order order = new Models.Order()
            {
                UserId = user.Id,
                TotalPrice = totalPrice,
                Status = Enums.OrderStatus.PENDING,
                Items = cartItems.Select(c => new Models.OrderItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                }).ToList()
            };

            _db.Orders.Add(order);

            dbUser.Balance -= totalPrice;
            user.Balance = dbUser.Balance;

            foreach (var item in cartItems)
            {
                item.Product.Stock -= item.Quantity;
            }

            _db.CartItems.RemoveRange(cartItems);
            _db.SaveChanges();
            Console.WriteLine($"Order placed successfully! Total spent: {totalPrice}$");
        }
        public void ViewOrderHistory(Models.User user)
        {
            var orders = _db.Orders
                .Where(o => o.UserId == user.Id)
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("You have no orders yet.");
                return;
            }

            Console.WriteLine("\n=== Your Order History ===");
            foreach (var o in orders)
            {
                Console.WriteLine($"Order ID: {o.Id} | Date: {o.CreateAt:yyyy-MM-dd} | Total: {o.TotalPrice}$ | Status: {o.Status}");
            }
        }

        public void CancelOrder(Models.User user)
        {
            Console.Write("Enter Order ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId && o.UserId == user.Id);

            if (order == null) throw new Exception("Order not found!");
            if (order.Status != OrderStatus.PENDING) throw new Exception("Only PENDING orders can be cancelled!");

            order.Status = OrderStatus.CANCELLED;

            var dbUser = _db.Users.Find(user.Id);
            if (dbUser == null) throw new Exception("User not found!");
            dbUser.Balance += order.TotalPrice;
            user.Balance = dbUser.Balance;

            foreach (var item in order.Items)
            {
                if (item.Product != null)
                {
                    item.Product.Stock += item.Quantity;
                }
            }
            _db.SaveChanges();
            Console.WriteLine("Order cancelled and funds returned.");
        }
        public void ViewAllOrders()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN) throw new Exception("Access Denied!");

            var orders = _db.Orders.Include(o => o.User).ToList();
            Console.WriteLine("\n=== All Orders (Admin) ===");
            foreach (var o in orders)
            {
                Console.WriteLine($"ID: {o.Id} | User: {o.User?.Username} | Total: {o.TotalPrice}$ | Status: {o.Status}");
            }
        }
        public void MarkOrderDelivered()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN) throw new Exception("Access Denied!");

            Console.Write("Enter Order ID to mark as Delivered: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders.Find(orderId);
            if (order == null) throw new Exception("Order not found!");

            order.Status = OrderStatus.DELIVERED;
            _db.SaveChanges();
            Console.WriteLine("Order marked as Delivered.");
        }

        public void AdminCancelOrder()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN) throw new Exception("Access Denied!");

            Console.Write("Enter Order ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault(o => o.Id == orderId);
            if (order == null) throw new Exception("Order not found!");

            order.Status = OrderStatus.CANCELLED;

            var user = _db.Users.Find(order.UserId);
            if (user != null) user.Balance += order.TotalPrice;

            foreach (var item in order.Items)
            {
                if (item.Product != null)
                    item.Product.Stock += item.Quantity;
            }
            _db.SaveChanges();
            Console.WriteLine("Order cancelled by admin.");
        }




        public void ViewOrderDetails()
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null) throw new Exception("Order not found!");

            Console.WriteLine($"\n--- Order Details (ID: {order.Id}) ---");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"Items:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.Product?.Name} | Qty: {item.Quantity} | Price: {item.Price}$");
            }
            Console.WriteLine($"Total Price: {order.TotalPrice}$");
        }

    }
}
