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
    internal class AuthSevices
    {
        public static string path = "Data/Users.json";
        public static List<User> Users = JsonHelper.LoadData<User>(path);
        public void Register()
        {
            Console.WriteLine("----- Register New User -----");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            if(Users.Any(u => u.Username == username || u.Email == email))
            {
                Console.WriteLine("User already exists!");
                return;
            }

            Users.Add(new User
            {
                Username = username,
                Email = email,
                Password = password,
            });

            JsonHelper.SaveData(path, Users);
            Console.WriteLine("Registration successful!");
        }

        public static User Login()
        {

           
            Console.WriteLine("----- User Login -----");
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

        //public void Logout()
        //{
        //    return;
        //}
    }
}
