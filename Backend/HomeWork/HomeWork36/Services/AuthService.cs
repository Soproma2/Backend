using HomeWork36.Data;
using HomeWork36.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HomeWork36.Services
{
    internal class AuthService
    {
        private DataContext _db = new DataContext();
        private SMTPService _smtpService = new SMTPService();

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username is required!");

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");

            Random rand =  new Random();
            string code = rand.Next(100_000, 999_999).ToString();

            User user = new User()
            {
                Email = email,
                Password = password,
                Username = username,
                VerificationCode = code
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
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required!");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required!");

            var user = _db.Users
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            if(!user.IsEmailConfirmed) throw new Exception("User is not verified!");

            Console.WriteLine("User logged in succesfully.");
            Console.WriteLine($"logged in user - username: {user.Username}, email: {user.Email}");
        }

        public void ShowUsers()
        {
            var users = _db.Users.ToList();

            foreach(var user in users)
            {
                Console.WriteLine($"username: {user.Username}, email: {user.Email}");
            }
        }
    }
}
