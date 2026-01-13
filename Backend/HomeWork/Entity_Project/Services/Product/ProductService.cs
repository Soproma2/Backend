using Entity_Project.Data;
using Entity_Project.Enums;
using Entity_Project.Migrations;
using Entity_Project.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Product
{
    internal class ProductService : IProductService
    {
        private readonly DataContext _db = new DataContext();
        public void ViewAllProducts()
        {
            var products = _db.Products.ToList();
            Console.WriteLine("/n=== Product List ===");
            foreach(var p in products)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Name} | Description: {p.Description} | Category: {p.Category} | Price: {p.Price}$ | Stock: {p.Stock}");
            }
        }
        public void AddProduct()
        {
            if(AuthService.CurrentUser?.Role != UserRole.ADMIN)
            {
                throw new Exception("Access Denied: Only Admins can add products!");
            }

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is required!");

            Console.Write("Enter Product Description: ");
            string description = Console.ReadLine();

            if (string.IsNullOrEmpty(description))
                throw new Exception("Description is required!");

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            if (price == 0)
                throw new Exception("Value is required!");

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            if (string.IsNullOrEmpty(category))
                throw new Exception("Category is required!");

            Console.Write("Enter Stock Quantity: ");
            int stock = int.Parse(Console.ReadLine());

            if (stock <= 0)
                throw new Exception("Description is required!");

            Models.Product product = new Models.Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Stock = stock,
                Category = category
            };

            _db.Products.Add(product);
            _db.SaveChanges();
            Console.WriteLine("Product added successfully!");


        }
        public void SearchProducts()
        {
            Console.Write("Search for: ");
            string term = Console.ReadLine().ToLower();

            var results = _db.Products
                .Where(p => p.Name.ToLower().Contains(term))
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine("No Prodcts found.");
                return;
            }

            foreach(var p in results)
                Console.WriteLine($"{p.Name} - {p.Price}$");
        }

        public void DeleteProduct()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN)
                throw new Exception("Access Denied!");

            Console.Write("Enter Product ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new Exception("Invalid Product ID!");

            var product = _db.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");

            _db.Products.Remove(product);
            _db.SaveChanges();
            Console.WriteLine("Product deleted.");
        }

        public void FilterByCategory()
        {
            throw new NotImplementedException();
        }


        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }


        public void ViewCategories()
        {
            throw new NotImplementedException();
        }

        public void ViewProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
