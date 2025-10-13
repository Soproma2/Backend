using HomeWork23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork23.Services
{
    public class UserServices
    {
        public User RegisterUser()
        {
            Console.WriteLine("REGISTRATION");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your E-Mail: ");
            string email = Console.ReadLine();

            return new User(name, email);
        }
    }
}
