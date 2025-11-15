using HomeWork32.Data;
using HomeWork32.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork32.Services.UserService
{
    internal class UserService : IUser
    {
        DataContext _db = new DataContext();
        public void Register()
        {
            Console.Write("Enter Firstname: ");
            string fname = Console.ReadLine();

            Console.Write("Enter Lastname: ");
            string lname = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = new User()
            {
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Password = password
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("User registered successfully.");
        }
        public User Login()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var user = _db.Users.FirstOrDefault(u=>u.Email == email && u.Password == password);
            if(user == null)
            {
                Console.WriteLine("Inavlid email or password!");
                return null;
            }

            Console.WriteLine($"Welcome, {user.Firstname} {user.Lastname}!");
            return user;
        }

    }
}
