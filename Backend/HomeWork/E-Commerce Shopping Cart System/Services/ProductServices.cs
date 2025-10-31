using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class ProductServices
    {
        public static string path = "Data/Products.json";
        public static List<Product> Products = JsonHelper.LoadData<Product>(path);
        public static void ViewAllProducts()
        {
            Console.WriteLine("\n--------Products-------");
            if (Products.Count == 0) { Console.WriteLine("Products are not available."); }
            foreach(var  product in Products)
            {
                Console.WriteLine($"{product.ProductId}. {product.Name} - {product.Price}$ - Stock: {product.Stock}");
            }
        }
        public static void SearchProducts()
        {
            Console.WriteLine("\n-------Search Products--------");
            Console.Write("Search by name: ");
            string keyword = Console.ReadLine();
            var result = Products.Where(p=>p.Name.ToLower().Contains(keyword)).ToList();
            if (result.Count == 0) Console.WriteLine("No products found!");
            else foreach (var product in result) Console.WriteLine($"{product.ProductId}. {product.Name} - {product.Price}$");
        }
        public static void FilterByCategory()
        {
            Console.WriteLine("\n-------Filter By Category--------");
            Console.Write("Enter category: ");
            string cat = Console.ReadLine().ToLower();
            var result = Products.Where(p=>p.Category.ToLower().Contains(cat)).ToList();
            if (result.Count == 0) Console.WriteLine("No products in this category!");
            else foreach (var product in result) Console.WriteLine($"{product.ProductId}. {product.Name} - {product.Price}$");
        }

        public static void ViewProductDetails()
        {
            Console.WriteLine("\n-------Product Details--------");
            Console.Write("Enter Product ID: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                var p = Products.FirstOrDefault(x=>x.ProductId == id);
                if (p == null) Console.WriteLine("Product not found!");
                else
                {
                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Description: {p.Description}"); 
                    Console.WriteLine($"Price: {p.Price}$"); 
                    Console.WriteLine($"Stock: {p.Stock}");
                    Console.WriteLine($"Category: {p.Category}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        public static void AddProduct()
        {
            Console.WriteLine("\n----- Add New Product -----");
            Console.Write("Enter product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter stock quantitiy: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string cat = Console.ReadLine();

            int id = Products.Count > 0 ? Products.Max(p => p.ProductId) + 1 : 1;
            Products.Add(new Product
            {
                ProductId = id,
                Name = name,
                Description = desc,
                Price = price,
                Stock = stock,
                Category = cat,
                CreatedDate = DateTime.Now
            });

            JsonHelper.SaveData(path, Products);
            Console.WriteLine("Product added!");
        }

        public static void UpdateProduct()
        {
            ViewAllProducts();
            Console.WriteLine("\n-------Update Product--------");
            Console.Write("Enter Product ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var p = Products.FirstOrDefault(x => x.ProductId == id);
                if (p == null) { Console.WriteLine("Product not found!"); return; }
                ;

                Console.Write("New Name (Enter to skip): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) p.Name = name;

                Console.Write("New Price (Enter to skip): ");
                string priceStr = Console.ReadLine();
                if (double.TryParse(priceStr, out double price)) p.Price = price;

                Console.Write("New Stock (Enter to skip): ");
                string stockStr = Console.ReadLine();
                if (int.TryParse(stockStr, out int stock)) p.Stock = stock;

                Console.Write("New Category (Enter to skip): ");
                string cat = Console.ReadLine();
                if (!string.IsNullOrEmpty(cat)) p.Category = cat;

                JsonHelper.SaveData(path, Products);
                Console.WriteLine("Product updated!");
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }

        public static void DeleteProduct()
        {
            ViewAllProducts();
            Console.WriteLine("\n-------Delete Product--------");
            Console.Write("Enter Product ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var p = Products.FirstOrDefault(x => x.ProductId == id);
                if (p == null) { Console.WriteLine("Product not found!"); return; }
                ;
                Products.Remove(p);
                JsonHelper.SaveData(path, Products);
                Console.WriteLine("Product deleted!");
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
    }
}
