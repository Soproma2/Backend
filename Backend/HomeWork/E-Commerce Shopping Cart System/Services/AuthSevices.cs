using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class AuthSevices
    {
        public static string path = "Data/Users.json";
        public static List<User> Users = JsonHelper.LoadData<User>(path);
        
        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("\n----- Register New User -----");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty!");
                return;
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Invalid email format!");
                return;
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long!");
                return;
            }

            if (Users.Any(u => u.Username == username || u.Email == email))
            {
                Console.WriteLine("User with this username or email already exists!");
                return;
            }

            int id = Users.Count > 0 ? Users.Max(u => u.UserId) + 1 : 1;

            Users.Add(new User
            {
                UserId = id,
                Username = username,
                Email = email,
                Password = password,
                CreatedDate = DateTime.Now
            });

            JsonHelper.SaveData(path, Users);
            Console.WriteLine("Registration successful!");
        }

        public static User Login()
        {
            Console.Clear();
           
            Console.WriteLine("\n----- User Login -----");
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var user = Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                Console.WriteLine("Invalid credentials!");
                return null;
            }
            Console.WriteLine($"Welcome {user.Username}!");
            return user;
        }
    }
}
