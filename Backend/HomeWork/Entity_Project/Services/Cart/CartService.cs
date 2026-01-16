using Entity_Project.Data;
using Entity_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Cart
{
    internal class CartService : ICartService
    {
        private readonly DataContext _db = new DataContext();
        public void AddToCart(Models.User user)
        {
            if (user == null) throw new Exception("User not logged in!");

            Console.Write("Enter Product Id to Add: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                throw new Exception("Invalid Product ID!");

            var product = _db.Products.Find(productId);
            if (product == null) throw new Exception("Product not found!");
            if (product.Stock <= 0)
            {
                throw new Exception($"Product '{product.Name}' is currently out of stock!");
            }

            Console.Write($"Enter quantity (Available: {product.Stock}): ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                throw new Exception("Invalid quantity! Quantity must be greater than 0.");

            if (quantity > product.Stock)
                throw new Exception("Not enough stock available!");

            var existingCartItem = _db.CartItems
                .Include(c => c.Product)
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if(existingCartItem != null)
            {
                int newTotalQuantity = existingCartItem.Quantity + quantity;

                if (newTotalQuantity > product.Stock)
                    throw new Exception($"Adding this quantity exceeds available stock! You already have {existingCartItem.Quantity} units in cart. Maximum you can add: {product.Stock - existingCartItem.Quantity}");

                existingCartItem.Quantity = newTotalQuantity;
                Console.WriteLine($"Updated quantity in cart. New total: {newTotalQuantity} units");
            }
            else
            {
                CartItem cartItem = new CartItem()
                {
                    UserId = user.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                _db.CartItems.Add(cartItem);
                Console.WriteLine($"Added {quantity} unit(s) of '{product.Name}' to cart.");
            }

            _db.SaveChanges();
            Console.WriteLine("Added to cart successfully");
        }
        public void ViewCart(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");
            var cartItems = _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!cartItems.Any())
            {
                Console.WriteLine("\nYour cart is empty.");
                return;
            }

            Console.WriteLine("\n=== Your Shopping Cart ===");
            double grandTotal = 0;

            foreach (var item in cartItems)
            {
                if (item.Product == null)
                {
                    Console.WriteLine($"Product ID {item.ProductId} not found (removed)");
                    continue;
                }
                double total = item.Product.Price * item.Quantity;
                grandTotal += total;
                Console.WriteLine($"ID: {item.ProductId} | {item.Product.Name} | Qty: {item.Quantity} | Price: {item.Product.Price}$ | Total: {total}$");
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Grand Total: {grandTotal}$");
            Console.WriteLine($"Your Balance: {user.Balance}$");

            if (grandTotal > user.Balance)
            {
                Console.WriteLine($"Insufficient funds! You need {(grandTotal - user.Balance)}$ more.");
            }
        }

        public void UpdateCartQuantity(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");

            Console.Write("Enter Product ID from cart to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                throw new Exception("Invalid Product ID!");

            var cartItem = _db.CartItems
                .Include(c => c.Product)
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if (cartItem == null) throw new Exception("Item not found in your cart!");
            if (cartItem.Product == null)
                throw new Exception("Product not found in database!");

            Console.Write($"Current quantity: {cartItem.Quantity}. Enter new quantity (Available stock: {cartItem.Product.Stock}): ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity))
                throw new Exception("Invalid quantity format!");

            if (newQuantity < 0)
                throw new Exception("Quantity cannot be negative!");

            if (newQuantity == 0)
            {
                _db.CartItems.Remove(cartItem);
                _db.SaveChanges();
                Console.WriteLine("Item removed from cart.");
                return;
            }
           
             if(newQuantity > cartItem.Product.Stock)
                throw new Exception($"Not enough stock! Only {cartItem.Product.Stock} units available.");

            cartItem.Quantity = newQuantity;
            _db.SaveChanges();
            Console.WriteLine("Quantity updated.");
        }
        public void RemoveFromCart(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");
            
            Console.Write("Enter Product Id to remove from cart: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                throw new Exception("Invalid Product ID!");

            var cartItem = _db.CartItems
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if (cartItem == null) throw new Exception("Item not found in your cart!");

            _db.CartItems.Remove(cartItem);
            _db.SaveChanges();
            Console.WriteLine("Product removed from cart.");
        }

        public void ClearCart(Models.User user)
        {
            if (user == null)
                throw new Exception("You must be logged in!");

            var userCartItems = _db.CartItems
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!userCartItems.Any())
            {
                Console.WriteLine("Your cart is already empty.");
                return;
            }

            Console.Write($"Are you sure you want to clear all {userCartItems.Count} item(s) from your cart? (y/n): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation != "y")
            {
                Console.WriteLine("Cart clear cancelled.");
                return;
            }
            _db.CartItems.RemoveRange(userCartItems);
            _db.SaveChanges();
            Console.WriteLine("Cart cleared successfully.");
        }



    }
}
