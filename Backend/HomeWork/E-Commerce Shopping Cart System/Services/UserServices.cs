using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class UserServices
    {
        public static string path = "Data/Users.json";
        public static List<User> Users = JsonHelper.LoadData<User>(path);
       
        public static void ViewProfile(User user)
        {
            Console.WriteLine("\n----- User Profile -----");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Balance: {user.Balance} $");
            Console.WriteLine($"Registered: {user.CreatedDate}");
            Console.WriteLine();
        }

        public static void AddBalance(User user)
        {
            Console.WriteLine("\n-------Add Balance-------");
            Console.Write("Enter amount to add: ");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                user.Balance += amount;
                JsonHelper.SaveData(path, Users);
                Console.WriteLine("Balance updated!");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }
    }
}
