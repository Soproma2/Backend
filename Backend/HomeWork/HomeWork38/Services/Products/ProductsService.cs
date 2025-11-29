using HomeWork38.Data;
using HomeWork38.Models;
using HomeWork38.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Services.Products
{
    internal class ProductsService : IProductsService
    {
        private DataContext _db = new DataContext();

        public void CreateProduct()
        {
            if (AuthService.CurrentUser == null)
                throw new Exception("Unauthorized!");

            Console.Write("Enter product title: ");
            string title = Console.ReadLine();

            Console.Write("Enter product stock: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter product expiers at: ");
            int expiersAt = int.Parse(Console.ReadLine());

            Product product = new Product()
            {
                UserId = AuthService.CurrentUser.Id,
                Title = title,
                Stock = stock,
                Price = price,
                ExpiersAt = DateTime.UtcNow.AddDays(expiersAt)
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            Console.WriteLine("Product created successfully.");
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void EditProduct()
        {
            throw new NotImplementedException();
        }

        public void FilterProducts()
        {
            throw new NotImplementedException();
        }

        public void OrderByPrice()
        {
            throw new NotImplementedException();
        }

        public void ShowProducts()
        {
            throw new NotImplementedException();
        }
    }
}
