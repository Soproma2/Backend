using E_Commerce_Shopping_Cart_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    internal class AdminServices
    {
        static string admin = "Niko";
        string filePath = "Products.json";
        static string ordersFile = "orders.json";
        public void AddProduct()
        {
            Product product = new Product();

            Console.WriteLine("----- Add New Product -----");
            Console.Write("Enter product Name: ");
            product.Name = Console.ReadLine();

            Console.Write("Enter description: ");
            product.Description = Console.ReadLine();

            Console.WriteLine("Enter price: ");
            product.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enetr stock quantitiy:");
            product.Stock = int.Parse(Console.ReadLine());

            Console.Write("Enter category:");
            product.Category = Console.ReadLine();

            List<Product> products = new List<Product>();

            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    products = JsonSerializer.Deserialize<List<Product>>(existingJson);
                }
            }

            products.Add(product);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, json);

            Console.WriteLine($"Product '{product.Name} added successfully'");
        }

        public void UpdateProduct()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Product file not found!");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

            if(products == null || products.Count == 0)
            {
                Console.WriteLine("No products found!");
                return;
            }

            Console.Write("Enter product name to update: ");
            string nameToUpdate = Console.ReadLine();

            Product product = products.Find(p => p.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

            if(product == null)
            {
                Console.Write("Product not found!");
                return;
            }

            Console.WriteLine($"Editing product: {product.Name}");
            Console.WriteLine("Press ENTER to skip updating a field.");

            Console.Write($"New description ({product.Description}): ");
            string newDesc = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newDesc)) product.Description = newDesc;

            Console.Write($"New price ({product.Price}): ");
            string newPriceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPriceInput))
            {
                if (double.TryParse(newPriceInput, out double newPrice))
                {
                    product.Price = newPrice;
                }
                else
                {
                    Console.WriteLine("Invalid price entered. Keeping previous value.");
                }
            }

            Console.Write($"New stock ({product.Stock})");
            string newStockInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newStockInput) && int.TryParse(newStockInput, out int newStock))
            {
                product.Stock = newStock;
            }

            Console.WriteLine($"New category ({product.Category})");
            string newCategory = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCategory)) product.Category = newCategory;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, updatedJson);

            Console.WriteLine("Product updated successfully");
        }

        public void DeleteProduct()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No product file found!");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

            if (products == null || products.Count == 0)
            {
                Console.WriteLine("No products found!");
                return;
            }

            Console.Write("Enter product name to delete: ");
            string nameToDelete = Console.ReadLine();

            Product product = products.Find(p=>p.Name.Equals(nameToDelete,StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            products.Remove(product);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(products,options);
            File.WriteAllText(filePath,updatedJson);

            Console.WriteLine($"Product '{product.Name}' deleted successfully!");
        }

        public void ViewAllOrders()
        {
            if (!File.Exists(ordersFile))
            {
                Console.WriteLine("Oreder file not found!");
                return;
            }

            string json = File.ReadAllText(ordersFile);
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(json);

            if(orders == null || orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("----- All Orders -----");
            foreach (Order order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}");
                Console.WriteLine($"User: {order.User?.Username ?? "Unknown"}");
                Console.WriteLine($"Product: {order.Product?.Name ?? "N/A"}");
                Console.WriteLine($"Quantity: {order.Quantity}");
                Console.WriteLine($"Price per unit: {order.Product?.Price} ₾");
                Console.WriteLine($"Created: {order.CreatedAt}");
                Console.WriteLine($"Status: {order.Status}");
                Console.WriteLine(new string('-', 45));
            }
        }
    }
}
