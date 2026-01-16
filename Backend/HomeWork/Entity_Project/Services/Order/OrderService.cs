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
            if (user == null) throw new Exception("You must be logged in to checkout!");

            
            var cartItemsFresh = _db.CartItems.AsNoTracking()
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!cartItemsFresh.Any()) throw new Exception("Your cart is empty!");

            var missingProducts = cartItemsFresh.Where(c => c.Product == null).ToList();
            if (missingProducts.Any())
            {
                throw new Exception($"{missingProducts.Count} product(s) in your cart no longer exist. Please update your cart.");
            }

            double totalPrice = 0;
            foreach (var item in cartItemsFresh)
            {
                double itemTotal = item.Product.Price * item.Quantity;
                totalPrice += itemTotal;
            }

            
            var dbUserFresh = _db.Users.AsNoTracking().FirstOrDefault(u => u.Id == user.Id);
            if (dbUserFresh == null)
                throw new Exception("User not found!");
            if (dbUserFresh.Balance < totalPrice)
                throw new Exception($"Insufficient balance! Needed: {totalPrice}$, Available: {dbUserFresh.Balance}$");

            
            var dbUser = _db.Users.Find(user.Id);
            if (dbUser == null)
                throw new Exception("User not found!");

            
            foreach (var item in cartItemsFresh)
            {
                if (item.Product == null)
                    throw new Exception($"Product ID {item.ProductId} not found.");
                if (item.Product.Stock < item.Quantity)
                    throw new Exception($"Product {item.Product.Name}. Insufficient quantity in stock | Stock: {item.Product.Stock}");
            }

            Models.Order order = new Models.Order()
            {
                UserId = user.Id,
                TotalPrice = totalPrice,
                Status = Enums.OrderStatus.PENDING,
                Items = cartItemsFresh.Select(c => new Models.OrderItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                }).ToList()
            };

            _db.Orders.Add(order);

            dbUser.Balance -= totalPrice;
            user.Balance = dbUser.Balance;

            
            foreach (var item in cartItemsFresh)
            {
                var prod = _db.Products.Find(item.ProductId);
                if (prod == null) throw new Exception($"Product ID {item.ProductId} not found when updating stock.");
                prod.Stock -= item.Quantity;
            }

            
            var cartItemIds = cartItemsFresh.Select(c => c.Id).ToList();
            var trackedCartItemsToRemove = _db.CartItems.Where(c => cartItemIds.Contains(c.Id)).ToList();
            _db.CartItems.RemoveRange(trackedCartItemsToRemove);
            _db.SaveChanges();
            
            if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == dbUser.Id)
            {
                AuthService.CurrentUser.Balance = dbUser.Balance;
            }
            Console.WriteLine($"Order placed successfully! Total spent: {totalPrice}$");
            Console.WriteLine($"Remaining balance: {user.Balance}$");
            Console.WriteLine($"Order status: {order.Status}");
        }
        public void ViewOrderHistory(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");

            var orders = _db.Orders.AsNoTracking()
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.CreateAt)
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("\nYou have no orders yet.");
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
            if (user == null)
                throw new Exception("You must be logged in!");

            Console.Write("Enter Order ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId && o.UserId == user.Id);

            if (order == null) throw new Exception("Order not found!");
            if (order.Status != OrderStatus.PENDING) throw new Exception("Only PENDING orders can be cancelled!");

            Console.Write($"Cancel order #{orderId} for {order.TotalPrice}$? (y/n): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation != "y")
            {
                Console.WriteLine("Cancellation aborted.");
                return;
            }

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
                else
                {
                    Console.WriteLine($"Product ID {item.ProductId} not found. Stock not restored.");
                }
            }
            _db.SaveChanges();
            
            if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == dbUser.Id)
            {
                AuthService.CurrentUser.Balance = dbUser.Balance;
            }
            Console.WriteLine("Order cancelled and funds returned.");
            Console.WriteLine($"Refunded: {order.TotalPrice}$");
            Console.WriteLine($"New balance: {user.Balance}$");
        }
        public void ViewAllOrders()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN) throw new Exception("Access Denied!");

            var orders = _db.Orders.AsNoTracking()
                .Include(o => o.User)
                .OrderByDescending(o => o.CreateAt)
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("\n=== All Orders ===");
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("\n=== All Orders ===");
            foreach (var o in orders)
            {
                Console.WriteLine($"ID: {o.Id} | User: {o.User?.Username} | Date: {o.CreateAt:yyyy-MM-dd} | Total: {o.TotalPrice}$ | Status: {o.Status}");
            }
        }
        public void MarkOrderDelivered()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN) throw new Exception("Access Denied!");

            Console.Write("Enter Order ID to mark as Delivered: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == orderId);
            if (order == null) throw new Exception("Order not found!");

            if (order.Status == OrderStatus.DELIVERED)
            {
                Console.WriteLine("This order is already marked as delivered.");
                return;
            }

            if (order.Status == OrderStatus.CANCELLED)
                throw new Exception("Cannot mark a cancelled order as delivered!");

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
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == orderId);
            if (order == null) throw new Exception("Order not found!");

            if (order.Status == OrderStatus.CANCELLED)
            {
                Console.WriteLine("This order is already cancelled.");
                return;
            }

            if (order.Status == OrderStatus.DELIVERED)
            {
                Console.Write("This order is already delivered. Cancel anyway? (y/n): ");
                string confirm = Console.ReadLine()?.Trim().ToLower();
                if (confirm != "y")
                {
                    Console.WriteLine("Cancellation aborted.");
                    return;
                }
            }

            var user = _db.Users.Find(order.UserId);
            if (user == null)
            {
                Console.WriteLine($"User ID {order.UserId} not found. Cannot refund.");
            }
            else
            {
                user.Balance += order.TotalPrice;
                
                if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == user.Id)
                {
                    AuthService.CurrentUser.Balance = user.Balance;
                }
                Console.WriteLine($"Refunded {order.TotalPrice}$ to {user.Username}");
            }

            int restoredItems = 0;
            foreach (var item in order.Items)
            {
                if (item.Product != null)
                {
                    item.Product.Stock += item.Quantity;
                    restoredItems++;
                }
                else
                {
                    Console.WriteLine($"Product ID {item.ProductId} not found. Stock not restored.");
                }
            }

            order.Status = OrderStatus.CANCELLED;
            _db.SaveChanges();
            
            if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == user?.Id)
            {
                AuthService.CurrentUser.Balance = user.Balance;
            }
            Console.WriteLine($"Order #{orderId} cancelled by admin.");
            Console.WriteLine($"Restored {restoredItems} product(s) to stock.");
        }




        public void ViewOrderDetails()
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
                throw new Exception("Invalid Order ID!");

            var order = _db.Orders.AsNoTracking()
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null) throw new Exception("Order not found!");

            if (AuthService.CurrentUser?.Role != UserRole.ADMIN &&
                AuthService.CurrentUser?.Id != order.UserId)
            {
                throw new Exception("Access Denied! You can only view your own orders.");
            }

            Console.WriteLine($"\n--- Order Details (ID: {order.Id}) ---");
            Console.WriteLine($"Customer:    {order.User?.Username ?? "Unknown"}");
            Console.WriteLine($"Order Date:  {order.CreateAt:yyyy-MM-dd}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"--- Items ---");

            double calculatedTotal = 0;
            foreach (var item in order.Items)
            {
                double itemTotal = item.Price * item.Quantity;
                calculatedTotal += itemTotal;

                string productName = item.Product?.Name ?? $"Product ID {item.ProductId} (removed)";
                Console.WriteLine($"    {productName}");
                Console.WriteLine($"    Quantity: {item.Quantity} x {item.Price}$ = {itemTotal}$");

            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Price: {order.TotalPrice}$");
        }
    }
}
