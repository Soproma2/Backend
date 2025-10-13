using HomeWork23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork23.Services
{
    public class ShopServices
    {
        private List<Product> products;
        public ShopServices()
        {
            products = new List<Product>()
            {
                new Product("Laptop", 2500),
                new Product("Mouse", 50),
                new Product("Keyboard", 120),

                
                new Product("Monitor 24\"", 699),
                new Product("Monitor 27\"", 999),
                new Product("Gaming Laptop", 3999),
                new Product("Ultrabook 14\"", 2799),

                
                new Product("Wireless Mouse", 79.99),
                new Product("Mechanical Keyboard", 189.99),
                new Product("Webcam 1080p", 149.99),
                new Product("USB Microphone", 179.99),
                new Product("Headphones", 129.50),
                new Product("Bluetooth Speaker", 219.99),


                new Product("External HDD 1TB", 229.99),
                new Product("External SSD 1TB", 449.99),
                new Product("NVMe SSD 1TB", 349.99),
                new Product("RAM 16GB DDR4", 159.99),
                new Product("RAM 32GB DDR4", 299.99),

                
                new Product("Graphics Card RTX 4060", 1999.99),
                new Product("Graphics Card RTX 4070", 2999.99),
                new Product("CPU Intel i5-12400F", 649.99),
                new Product("CPU AMD Ryzen 5 5600", 579.99),
                new Product("Motherboard B550", 399.99),
                new Product("Power Supply 650W 80+ Gold", 299.99),
                new Product("PC Case ATX", 199.99),

                
                new Product("Wi‑Fi 6 Router", 249.99),
                new Product("USB-C Hub (7-in-1)", 129),
                new Product("Phone Charger 30W", 59.99),
                new Product("USB-C Cable 1m", 19.99),
                new Product("HDMI Cable 2m", 24.99),
                new Product("Portable Power Bank 20,000mAh", 139.99),
                new Product("Desk Lamp LED", 49.99),
                new Product("Laptop Stand", 69.99),
            };
        }

        public void ShowProducts()
        {
            Console.WriteLine("Product list");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}. {products[i].Name} - {products[i].Price} $");   
            }
        }

        public void BuyProduct(User user)
        {
            ShowProducts();
            Console.Write("Select Product Number: ");
            int choice;
            if(int.TryParse(Console.ReadLine(), out choice) && choice >=1 && choice <= products.Count)
            {
                Product selected = products[choice - 1];
                Console.WriteLine($"You bought: {selected.Name}");
                SavePurchaseToFile(user, selected);
            }
            else
            {
                Console.WriteLine("Wrong choice!");
            }
        }
        private void SavePurchaseToFile(User user, Product product)
        {
            string folderPath = Path.Combine("Data", "USerFiles");
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{user.Name}.txt");
            string text = $"{DateTime.Now}: {product.Name} - {product.Price} $";

            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
