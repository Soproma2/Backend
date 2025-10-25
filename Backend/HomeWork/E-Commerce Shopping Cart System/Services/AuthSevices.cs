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
        string filePath = "users.txt";
        static string currentUser = null;
        public void Register()
        {
            Console.WriteLine("----- Register New User -----");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            if (File.Exists(filePath))
            {
                using (FileStream readStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(readStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length > 1 && data[1] == email)
                        {
                            Console.WriteLine("This email is already registered!");
                            return;
                        }
                    }              
                }
            }

            string newUser = $"{username},{email},{password}{Environment.NewLine}";
            byte[] databytes = Encoding.UTF8.GetBytes(newUser);

            using (FileStream writeStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                writeStream.Write(databytes,0, databytes.Length);
            }

            Console.WriteLine("Registration successful!");
        }

        public void Login()
        {

            if (currentUser != null)
            {
                Console.WriteLine($"User {currentUser} is already logged in!");
                return;
            }
            Console.WriteLine("----- User Login -----");
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No users registered yet!");
                return;
            }

            bool found = false;

            using (FileStream readStream = new FileStream(filePath, FileMode.Open,FileAccess.Read))
            using (StreamReader reader = new StreamReader(readStream))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if(data.Length >= 3 && data[1] == email && data[2] == password)
                    {
                        currentUser = data[0];
                        Console.WriteLine($"Welcome back, {data[0]}!");
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Invalid email or password!");
            }

        }

        public void Logout()
        {
            if (currentUser == null)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            Console.WriteLine($"Goodbye, {currentUser}");
            currentUser = null;
        }
    }
}
