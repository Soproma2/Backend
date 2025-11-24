using HomeWork37.Data;
using HomeWork37.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork37.Services.Auth
{
    internal class AuthService : IAuthService
    {
        DataContext _db = new DataContext();
        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username is required!");
            }

            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is required!");
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required!");
            }

            var hasedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User()
            {
                Username = hasedPassword,
                Email = email,
                Password = password
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("User registered successfuly.");
        }
        public void Login()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is required!");
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required!");
            }

            var user = _db.Users.FirstOrDefault(e=>e.Email == email);

            if (user == null)
            {
                throw new Exception("Incorrect password or email!");
            }

            var isVerified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isVerified)
            {
                throw new Exception("Incorrect password or email!");
            }

            Console.WriteLine("Success");
            Console.WriteLine($"logged in user: {user.Username}, email: {user.Email}");
        }

    }
}
