using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    internal class AuthSevices
    {
        string filePath = "users.txt";
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

        }

        public void Logout()
        {

        }
    }
}
