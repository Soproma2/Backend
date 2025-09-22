using ClassWork15;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ClassWork15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string filePath = "books.xml";
            //XmlSerializer serializer = new XmlSerializer(typeof(Book));

            //Book book = new Book() { Title = "Title", Author = "Author" };

            //using (FileStream fs = new FileStream(filePath,FileMode.Create))
            //{
            //    serializer.Serialize(fs,book);
            //}


            string filePath = "users.xml";
            List<User> users = new List<User>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

            void Register()
            {
                Console.WriteLine("Register");
                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("password: ");
                string password = Console.ReadLine();

                User user = new User() { Email = email, Password = password };
                users.Add(user);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, users);
                }

            }
            Register();

            void LoadUsers()
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    users = (List<User>)serializer.Deserialize(fs);
                }
            }

            LoadUsers();
        }
    }

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
    }
    //public class Book
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}
}



