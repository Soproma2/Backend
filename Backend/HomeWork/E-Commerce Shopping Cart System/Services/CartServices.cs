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
            Console.Write("Enter Product Id to add: ");
            if (!int.TryParse(Console.ReadLine(), out int pid)) { Console.WriteLine("Invalid Id!"); return; }
            var product = ProductServices.Products.FirstOrDefault(p => p.Id == Convert.ToString(pid));
            if (product == null) { Console.WriteLine("Product not found!"); return; }

            Console.Write("Enter quantity: ");
            if(!int.TryParse(Console.ReadLine(), out int qty)) { Console.WriteLine("Invalid quantity!"); return; }
            if (qty > product.Stock) { Console.WriteLine("Not enough stock!"); return; }

            var cart = CartItems.FirstOrDefault(c => c.User.Id == user.Id && c.Product.Id == Convert.ToString(pid));
            if (cart != null) cart.Quantity += qty;
            else
            {
                CartItems.Add(new CartItem
                {
                    User = user,
                    Product = product,
                    Quantity = qty,
                });
            }
            JsonHelper.SaveData(path, CartItems);
            Console.WriteLine("Added to cart!");
        }
        public void RemoveFromCart(User user)
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
