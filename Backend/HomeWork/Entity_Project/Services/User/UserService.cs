using Entity_Project.Data;
using Entity_Project.Models;
using Entity_Project.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.User
{
    internal class UserService : IUserService
    {
        private readonly DataContext _db = new DataContext();
        public void ViewProfile(Models.User user)
        {
            if (user == null) throw new Exception("You must be logged in!");
            Console.WriteLine("\n=== Your Profile ===");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Balance: {user.Balance}$");

            Console.WriteLine($"Full Name: {user.Profile?.FullName ?? "Not set"}");
            Console.WriteLine($"Address: {user.Profile?.Address ?? "Not set"}");
            Console.WriteLine($"Phone: {user.Profile?.PhoneNumber ?? "Not set"}");
        }

        public void AddBalance(Models.User user)
        {
            if (user == null) throw new Exception("Unauthorized! You must be logged in.");

            Console.Write("Enter amount to add: ");

            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                var dbUser = _db.Users.Find(user.Id);
                if (dbUser == null) throw new Exception("User not found!");
                dbUser.Balance += amount;
                _db.SaveChanges();

                user.Balance = dbUser.Balance;

                
                if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == dbUser.Id)
                {
                    AuthService.CurrentUser.Balance = dbUser.Balance;
                }

                Console.WriteLine($"Balance updated! New balance: {user.Balance}$");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }

        public void UpdateProfile(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");

            var profile = _db.Profiles.Find(user.Id);
            if (profile == null) throw new Exception("Profile not found!");

            Console.WriteLine("\n=== Update Profile ===");
            Console.WriteLine("(Leave blank to keep current value)");

            Console.Write($"Enter Full Name [{profile.FullName}]: ");
            string? fullName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fullName)) profile.FullName = fullName;

            Console.Write($"Enter Address [{profile.Address}]: ");
            string? address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address)) profile.Address = address;

            Console.Write($"Enter Phone Number [{profile.PhoneNumber}]: ");
            string? phoneNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phoneNumber)) profile.PhoneNumber = phoneNumber;

            _db.SaveChanges();

            if (user.Profile != null)
            {
                user.Profile.FullName = profile.FullName;
                user.Profile.Address = profile.Address;
                user.Profile.PhoneNumber = profile.PhoneNumber;
            }

            
            if (AuthService.CurrentUser != null && AuthService.CurrentUser.Id == user.Id)
            {
                if (AuthService.CurrentUser.Profile == null)
                    AuthService.CurrentUser.Profile = new Models.Profile();

                AuthService.CurrentUser.Profile.FullName = profile.FullName;
                AuthService.CurrentUser.Profile.Address = profile.Address;
                AuthService.CurrentUser.Profile.PhoneNumber = profile.PhoneNumber;
            }

            Console.WriteLine("Profile updated successfully!");
        }

    }
}
