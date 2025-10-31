using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class CartServices
    {
        public static string path = "Data/Cart.json";
        public static List<CartItem> CartItems = JsonHelper.LoadData<CartItem>(path);
        public static void AddToCart(User user)
        {
            ProductServices.ViewAllProducts();
            Console.WriteLine("\n-------Add To Cart-------");
            Console.Write("Enter Product Id to add: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Invalid Id!"); return; }
            var product = ProductServices.Products.FirstOrDefault(p => p.ProductId == pid);
            if (product == null) { Console.WriteLine("Product not found!"); return; }

            Console.Write("Enter quantity: ");
            if(!int.TryParse(Console.ReadLine(), out int qty)) { Console.WriteLine("Invalid quantity!"); return; }
            if (qty > product.Stock) { Console.WriteLine("Not enough stock!"); return; }

            var cart = CartItems.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == pid);
             if (cart != null) cart.Quantity += qty;
        else
        {
            int id = CartItems.Count > 0 ? CartItems.Max(c => c.CartId) + 1 : 1;
            CartItems.Add(new CartItem { CartId = id, UserId = user.UserId, ProductId = pid, Quantity = qty, AddedDate = DateTime.Now });
        }
            JsonHelper.SaveData(path, CartItems);
            Console.WriteLine("Added to cart!");
        }
        public static void RemoveFromCart(User user)
        {
            ViewCart(user);
            Console.WriteLine("\n-------Remove From Cart-------");
            Console.Write("Enter Product ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Invalid ID!"); return; }
            var cart = CartItems.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == pid);
            if (cart == null) { Console.WriteLine("Not in cart!"); return; }
            CartItems.Remove(cart);
            JsonHelper.SaveData(path, CartItems);
            Console.WriteLine("Removed from cart!");
        }
        public static void ViewCart(User user)
        {
            Console.WriteLine("\n-------Cart-------");
            var cart = CartItems.Where(c => c.UserId == user.UserId).ToList();
            if (cart.Count == 0) { Console.WriteLine("Cart empty!"); return; }
            double total = 0;
            foreach (var c in cart)
            {
                var p = ProductServices.Products.FirstOrDefault(x => x.ProductId == c.ProductId);
                if(p != null)
                {
                    double price = c.Quantity * p.Price;
                    total += price;
                    Console.WriteLine($"{p.Name} x {c.Quantity} = {price}$");
                }
            }
            Console.WriteLine($"Total: {total}$");
        }
        public static void UpdateCartQuantity(User user)
        {
            ViewCart(user);
            Console.WriteLine("\n-------Update Cart Quantity-------");
            Console.Write("Enter Product Id to update: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Invalid ID!"); return; }
            var cart = CartItems.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == pid);
            if (cart == null) { Console.WriteLine("Not in cart!"); return; }
            Console.Write("Enter new quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty)) { Console.WriteLine("Invalid quantity!"); return; }
            cart.Quantity = qty;
            JsonHelper.SaveData(path, CartItems);
            Console.WriteLine("Cart updated!");
        }
    }
}
