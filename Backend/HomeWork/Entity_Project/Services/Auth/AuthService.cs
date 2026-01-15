using Entity_Project.Data;
using Entity_Project.Services.SMTP;
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
        private SmtpService _smtpService = new SmtpService();
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
            if (_db.Users.Any(u => u.Email == email))
                throw new Exception("Email already exists!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Random rand = new Random();
            string code = rand.Next(100_000, 999_999).ToString();

            Models.User user = new Models.User()
            {
                Username = username,
                Email = email,
                Password = hashedPassword,
                Role = Enums.UserRole.USER,
                Balance = 0,
                VerificationCode = code,
                Profile = new Models.Profile
                {
                    FullName = "",
                    Address = "",
                    PhoneNumber = ""
                }
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            string body = $"This is your verification code: {code}";
            _smtpService.SendEmail("Email verification", user.Email, body);
            Console.WriteLine("Verification code sent successfully.");

        }


        public void VerifyEmail()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");

            Console.Write("Enter verification code: ");
            string code = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(code))
                throw new Exception("Code is required!");

            var user = _db.Users.FirstOrDefault(e => e.Email == email);

            if (user == null) throw new Exception("User not found!");

            if (user.VerificationCode != code)
                throw new Exception("Verification code is not correct!");


            user.VerificationCode = string.Empty;
            user.IsEmailConfirmed = true;


            _db.SaveChanges();

            Console.WriteLine("User email verified successfully.");
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

            if (!user.IsEmailConfirmed) throw new Exception("User is not verified!");

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
