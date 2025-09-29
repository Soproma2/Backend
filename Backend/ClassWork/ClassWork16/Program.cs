using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ClassWork16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uservalidation validator = new Uservalidation();

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            User user = new User() {  Username = username, Email = email, Password = password };

            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            Console.WriteLine("User registered!");

        }
    }
}
