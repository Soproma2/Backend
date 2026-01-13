using Entity_Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Auth
{
    internal class AuthService : IAuthService
    {
        private readonly DataContext _db = new DataContext();
        public static Models.User? CurrentUser { get; private set; }
        public void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Registration ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
                throw new Exception("Username is required!");
            if (_db.Users.Any(u => u.Username == username))
                throw new Exception("Username already exists!");

            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");
            if (_db.Users.Any(u => u.Username == email))
                throw new Exception("Email already exists!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Models.User user = new Models.User()
            {
                Username = username,
                Email = email,
                Password = hashedPassword,
                Role = Enums.UserRole.USER,
                Balance = 0,
                Profile = new Models.Profile
                {
                    FullName = "",
                    Address = "",
                    PhoneNumber = ""
                }
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            Console.WriteLine("Registered successfully.");

        }

        public void Login()
        {
            Console.WriteLine("=== Login ===");

            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            var user = _db.Users
                .Include(u => u.Profile)
                .FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new Exception("Invalid email or password!");

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception("Invalid email or password!");

            CurrentUser = user;
            Console.WriteLine($"Logged in successfully. Welcome, {user.Username}!");
        }

        public void Logout()
        {
            CurrentUser = null;
            Console.WriteLine("Logged out successfully.");
        }
    }
}
