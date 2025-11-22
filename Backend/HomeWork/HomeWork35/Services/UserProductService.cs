using HomeWork35.Data;
using HomeWork35.Models;
using Microsoft.EntityFrameworkCore;
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
            Console.Write("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var user = _db.Users.Find(userId);
            if(user == null)
            {
                Console.WriteLine("User Not Found!");
                return;
            }

            var product = _db.Products.Find(productId);
            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
                return;
            }

            UserProduct userProduct = new UserProduct()
            {
                UserId = user.Id,
                ProductId = product.Id
            };

            _db.UserProducts.Add(userProduct);
            _db.SaveChanges();
            Console.WriteLine("UserProduct created successfuly.");
        }

        public void ShowUsers()
        {
            var users = _db.Users.ToList();
            if(users.Count == 0 || users == null)
            {
                Console.WriteLine("Users not found!");
                return;
            }
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. Name: {user.Name} | Email: {user.Email}");
            }
        }

        public void ShowUser()
        {
            Console.Write("Enter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            var user = _db.Users
                .Include(u=>u.UserProducts)
                .ThenInclude(p=>p.Product)
                .FirstOrDefault(u=>u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            Console.WriteLine($"\nName: {user.Name} \nEmail: {user.Email} \n\nUserProducts: \n");
            foreach(var product in user.UserProducts)
            {
                Console.WriteLine($"Product Name: {product.Product.Name} \nDescription: {product.Product.Description}");
            }
        }

        public void ShowProducts()
        {
            var products = _db.Products.ToList();
            if (products.Count == 0 || products == null)
            {
                Console.WriteLine("Products not found!");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. Product Name: {product.Name} | {product.Description}");
            }
        }

        public void ShowProduct()
        {
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var product = _db.Products
                .Include(u => u.UserProducts)
                .ThenInclude(p => p.User)
                .FirstOrDefault(u => u.Id == productId);
            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            Console.WriteLine($"\nProduct Name: {product.Name} \nDescription: {product.Description} \n\nUsers who have this product:\n");
            foreach (var user in product.UserProducts)
            {
                Console.WriteLine($"User Name: {user.User.Name} \nEmail: {user.User.Email}");
            }
        }
    }
}
