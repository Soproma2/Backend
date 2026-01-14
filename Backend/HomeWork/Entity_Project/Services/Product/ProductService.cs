using Entity_Project.Data;
using Entity_Project.Enums;
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

        public void ViewCategories()
        {
            var allCategories = _db.Products
                .GroupBy(p=> p.Category)
                .Select(p=> p.Key)
                .ToList();

            if (!allCategories.Any())
            {
                Console.WriteLine("No categories found.");
                return;
            }

            foreach (var category in allCategories)
            {
                Console.WriteLine($"- {category}");
            }
        }

        public void FilterByCategory()
        {
            ViewCategories();

            Console.Write("/nEnter category name to filter: ");
            string categoryInput = Console.ReadLine();
            if (categoryInput == null) throw new Exception("Category is required!");

            var products = _db.Products
                .Where(p => p.Category.ToLower() == categoryInput.ToLower())
                .ToList();

            if (!products.Any())
            {
                Console.WriteLine($"No products found in category: {categoryInput}");
                return;
            }

            Console.WriteLine($"\n=== Products in {categoryInput} ===");
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Name} | Description: {p.Description} | Price: {p.Price}$");
            }
        }

        public void ViewProductDetails()
        {
            Console.Write("Enter Product ID to view details: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new Exception("Invalid ID format!");

            var product = _db.Products.Find(id);
            if (product == null)
                throw new Exception("Product not found!");
           
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Name:        {product.Name}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Category:    {product.Category}");
            Console.WriteLine($"In Stock:    {product.Stock}");
            Console.WriteLine($"Price:       {product.Price}$");
            Console.WriteLine("----------------------------");
        }

        public void UpdateProduct()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN)
                throw new Exception("Access Denied: Admin only!");

            Console.Write("Enter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new Exception("Invalid ID format!");

            var product = _db.Products.Find(id);
            if (product == null)
                throw new Exception("Product not found!");

            Console.WriteLine($"\nUpdating Product: {product.Name}");
            Console.WriteLine("Leave blank to keep current value.");

            Console.Write($"New Name [{product.Name}]: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) product.Name = name;

            Console.Write($"New Description: ");
            string desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc)) product.Description = desc;

            Console.Write($"New Category [{product.Category}]: ");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) product.Category = category;

            Console.Write($"New Price [{product.Price}]: ");
            string price = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(price)) product.Price = double.Parse(price);

            Console.Write($"New Stock [{product.Stock}]: ");
            string stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput)) product.Stock = int.Parse(stockInput);

            _db.SaveChanges();
            Console.WriteLine("Product updated successfully!");
        }



    }
}
