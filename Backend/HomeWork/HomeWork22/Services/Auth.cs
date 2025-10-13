using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork22.Services
{
    public static class Auth
    {
        const string UsersFile = "users.txt";
        public static void RegisterUser()
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();


            Console.Write("Enter E-Mail: ");
            string? email = Console.ReadLine();

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Please enter your email address.");
            }

            if (!isEmailUnique(email))
            {
                Console.WriteLine("This email is already used!");
                return;
            }

            Console.Write("Enter password: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Name or password cannot be empty!");
                return;
            }

            using (FileStream fs = new FileStream(UsersFile, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"Name:{name} - Email:{email} - Password:{password}");
            }
            Console.WriteLine("Registered successfully!");
        }

        public static bool isEmailUnique(string email)
        {
            if (!File.Exists(UsersFile))
            {
                return true;
            }

            using (FileStream fs = new FileStream(UsersFile, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();

                if (content.Contains($"Email:{email}", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                return true;
            }
        }

        public static void ShowUsers()
        {
            if (!File.Exists(UsersFile))
            {
                Console.WriteLine("users.txt file does not exist yet!");
                return;
            }

            Console.WriteLine("--USERS--");

            using (FileStream fs = new FileStream(UsersFile, FileMode.Open))
            using(StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("no users yet!");
                    return;
                }
                Console.WriteLine(content);
            }
        }
    }
}
