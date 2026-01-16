using Entity_Project.Data;
using Entity_Project.Enums;
using Entity_Project.Services.Auth;
using Microsoft.EntityFrameworkCore;
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
            var products = _db.Products.AsNoTracking().ToList();
            if (!products.Any())
            {
                Console.WriteLine("\n=== Product List ===");
                Console.WriteLine("No products available.");
                return;
            }
            Console.WriteLine("\n=== Product List ===");
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

            Console.WriteLine("\n=== Add New Product ===");

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                throw new Exception("Product name is required!");

            Console.Write("Enter Product Description: ");
            string description = Console.ReadLine();

            if (string.IsNullOrEmpty(description))
                throw new Exception("Description is required!");

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            if (price <= 0)
                throw new Exception("Price must be greater than 0!");

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            if (string.IsNullOrEmpty(category))
                throw new Exception("Category is required!");

            Console.Write("Enter Stock Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
                throw new Exception("Invalid stock quantity!");

            if (stock <= 0)
                throw new Exception("Stock must be greater than 0!");

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
            Console.WriteLine($"Product '{name}' added successfully");


        }
        public void SearchProducts()
        {
            Console.Write("Search for: ");
            string term = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(term)) throw new Exception("Search term is required!");

            var results = _db.Products.AsNoTracking()
                .Where(p => p.Name.ToLower().Contains(term) ||
                           p.Description.ToLower().Contains(term) ||
                           p.Category.ToLower().Contains(term))
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine("No Products found.");
                return;
            }

            Console.WriteLine($"\n=== Search Results for '{term}' ===");

            foreach (var p in results)
                Console.WriteLine($"ID: {p.Id} | {p.Name} | Category: {p.Category} | Price: {p.Price}$ | Stock: {p.Stock}");
        }

        public void DeleteProduct()
        {
            if (AuthService.CurrentUser?.Role != UserRole.ADMIN)
                throw new Exception("Access Denied! Only Admins can delete products.");

            Console.Write("Enter Product ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new Exception("Invalid Product ID!");

            var product = _db.Products
                .Include(p => p.CartItems)
                .Include(p => p.OrderItems)
                .FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("Product not found!");

            if (product.CartItems != null && product.CartItems.Any())
            {
                Console.WriteLine($"Warning: This product is in {product.CartItems.Count} shopping cart(s).");
                Console.Write("Do you still want to delete? (yes/no): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation != "yes")
                {
                    Console.WriteLine("Deletion cancelled.");
                    return;
                }

                _db.CartItems.RemoveRange(product.CartItems);
            }

            if (product.OrderItems != null && product.OrderItems.Any())
            {
                Console.WriteLine($"Warning: This product is in {product.OrderItems.Count} order(s).");
                Console.WriteLine("Cannot delete product that has been ordered. Consider marking it as out of stock instead.");
                return;
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            Console.WriteLine($"Product '{product.Name}' deleted successfully.");
        }

        public void ViewCategories()
        {
            var allCategories = _db.Products.AsNoTracking()
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderBy(x => x.Category)
                .ToList();

            if (!allCategories.Any())
            {
                Console.WriteLine("No categories found.");
                return;
            }

            Console.WriteLine("\n=== Available Categories ===");
            foreach (var category in allCategories)
            {
                Console.WriteLine($"- {category.Category} ({category.Count} products)");
            }
        }

        public void FilterByCategory()
        {
            ViewCategories();

            Console.Write("\nEnter category name to filter: ");
            string categoryInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(categoryInput))
                throw new Exception("Category is required!");

            var products = _db.Products.AsNoTracking()
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

            var product = _db.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
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
            string priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!double.TryParse(priceInput, out double price))
                    throw new Exception("Invalid price format!");

                if (price <= 0)
                    throw new Exception("Price must be greater than 0!");

                product.Price = price;
            }

            Console.Write($"New Stock [{product.Stock}]: ");
            string stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput))
            {
                if (!int.TryParse(stockInput, out int stock))
                    throw new Exception("Invalid stock format!");

                if (stock < 0)
                    throw new Exception("Stock cannot be negative!");

                product.Stock = stock;
            }


            _db.SaveChanges();
            Console.WriteLine("Product updated successfully!");
        }



    }
}
