using E_Commerce_Shopping_Cart_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    internal class CartServices
    {
        static string cartFile = "cart.json";
        static User currentUser = new User();
        static List<Product> products = new List<Product>();
        public void AddToCart()
        {
            Console.WriteLine("Available Products: ");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - {item.Price} $");
            }

            Console.Write("Select product number to add to cart: ");
            if (!int.TryParse(Console.ReadLine(), out int productIndex) || productIndex < 1 || productIndex > products.Count)
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Product selectedProduct = products[productIndex - 1];

            Console.Write($"Enter quantity for {selectedProduct.Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity!");
                return;
            }

            List<CartItem> cartItems = new List<CartItem>();
            if (File.Exists(cartFile))
            {
                string existingJson = File.ReadAllText(cartFile);
                cartItems = JsonSerializer.Deserialize<List<CartItem>>(existingJson);
            }

            CartItem existingItem = cartItems.Find(ci => ci.User.Username == currentUser.Username && ci.Product.Name == selectedProduct.Name);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    User = currentUser,
                    Product = selectedProduct,
                    Quantity = quantity
                });

            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(cartItems, options);
            File.WriteAllText(cartFile, updatedJson);

            Console.WriteLine($"Added {quantity} x {selectedProduct.Name} to cart!");
        }
        public void RemoveFromCart()
        {

        }
        public void ViewCart()
        {

        }
        public void UpdateCartQuantity()
        {

        }
    }
}
