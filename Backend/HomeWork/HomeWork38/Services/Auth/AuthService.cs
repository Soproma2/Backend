using HomeWork38.Data;
using HomeWork38.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Services.Auth
{
    internal class AuthService : IAuthService
    {
        private DataContext _db = new DataContext();
        public static User? CurrentUser { get; private set; }

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username is required!");

            Console.Write("Enter email");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");

            Console.Write("Enter password");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");

            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User()
            {
                Username = username,
                Email = email,
                Password = HashedPassword,
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("Registered successfully.");
        }

        public void Login()
        {
            Console.Write("Enter email");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");

            Console.Write("Enter password");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");

            var user = _db.Users.FirstOrDefault(e => e.Email == email);

            if (user == null) throw new Exception("Invalid email or password!");

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isPasswordCorrect)
                throw new Exception("Invalid email or password!");

            Console.WriteLine("Logged in successfully.");
            CurrentUser = user;
        }
    }
}
