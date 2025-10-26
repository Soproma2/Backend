using E_Commerce_Shopping_Cart_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    internal class UserServices
    {
        static string ordersFile = "orders.json";
        static string usersFile = "users.json";
        static User currentUser = new User
        {
            Username = "Niko",
            Email = "niko@gmail.com",
            CreatedAt = new DateTime(2025, 1, 10)
        };
        public void ViewProfile()
        {
            Console.WriteLine("----- User Profile -----");
            Console.WriteLine($"Username: {currentUser.Username}");
            Console.WriteLine($"Email: {currentUser.Email}");
            Console.WriteLine($"Balance: {currentUser.Balance} $");
            Console.WriteLine($"Registered: {currentUser.CreatedAt}");
            Console.WriteLine();

            List<Order> allOrders = new List<Order>();

            if (File.Exists(ordersFile))
            {
                string json = File.ReadAllText(ordersFile);
                allOrders = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }

            var myOrders = allOrders.Where(o => o.User?.Username == currentUser.Username).ToList();

            Console.WriteLine($"Total Orders: {myOrders.Count}");
            Console.WriteLine($"Items in Cart: {currentUser.CartItems.Count}");

            if (myOrders.Count>0)
            {
                Console.WriteLine("----- Your Orders -----");
                foreach (var order in myOrders)
                {
                    Console.WriteLine($"{order.Product?.Name ?? "unknown"} | Qty: {order.Quantity} | Status: {order.Status}");
                }
            }

            Console.WriteLine("-----------------------------------");
        }

        public void AddBalance()
        {
            Console.WriteLine($"Current Balance: {currentUser.Balance} $");
            Console.Write("Enter amount to add: ");

            if (!double.TryParse(Console.ReadLine(), out double amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            currentUser.Balance = amount;
            Console.WriteLine($"New Balance: {currentUser.Balance} $");

            List<User> users = new List<User>();
            if (File.Exists(usersFile))
            {
                string json = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }

            int index = users.FindIndex(u=>u.Username == currentUser.Username);
            if (index >= 0)
            {
                users[index].Balance = currentUser.Balance;
            }
            else
            {
                users.Add(currentUser);
            }

            var options = new JsonSerializerOptions { WriteIndented = true};
            string updatedJson = JsonSerializer.Serialize(users, options);
            File.WriteAllText(usersFile, updatedJson);

            Console.WriteLine("Balance updated successfully!");
        }
    }
}
