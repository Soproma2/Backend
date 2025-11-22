using HomeWork35.Data;
using HomeWork35.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HomeWork35.Services
{
    internal class UserProductService
    {
        DataContext _db = new DataContext();

        public void CreateUser()
        {
            Console.Write("Enter User Firstname: ");
            string fname = Console.ReadLine();

            Console.Write("Enter User Lastname: ");
            string lname = Console.ReadLine();

            Console.Write("Enter User Email: ");
            string email = Console.ReadLine();

            User user = new User()
            {
                Name = $"{fname} {lname}",
                Email = email
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            Console.WriteLine("User Created Successfully.");
        }

        public void CreateProduct()
        {
            Console.Write("Enter Product Name: ");
            string pname = Console.ReadLine();

            Console.Write("Enter Product Description: ");
            string description = Console.ReadLine();

            Product product = new Product()
            {
                Name = pname,
                Description = description
            };

            _db.Products.Add(product);
            _db.SaveChanges();
            Console.WriteLine("Product Created Successfully.");
        }

        public void UserProduct()
        {
            Console.WriteLine("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var user = _db.Users.Find(userId);
            if(user == null)
            {
                Console.WriteLine("User Not Found!");
            }

            var product = _db.Products.Find(productId);
            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
            }


        }

        public void ShowUsers()
        {

        }

        public void ShowUser()
        {

        }

        public void ShowProducts()
        {

        }

        public void ShowProduct()
        {

        }
    }
}
