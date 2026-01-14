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

            Console.Write($"Enter quantity (Available: {product.Stock})");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                throw new Exception("Invalid quantity!");

            if (quantity > product.Stock)
                throw new Exception("not eanogh stock available!");

            var existingCarItem = _db.CartItems
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if(existingCarItem != null)
            {
                if (existingCarItem.Quantity + quantity > product.Stock)
                    throw new Exception("Adding this quantity exceeds available stock!");

                existingCarItem.Quantity += quantity;
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
            }

            _db.SaveChanges();
            Console.WriteLine("Added to cart successfully");
        }
        public void ViewCart(Models.User user)
        {
            var cartItems = _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!cartItems.Any())
            {
                Console.WriteLine("/nYour cart is empty.");
                return;
            }

            Console.WriteLine("/n=== Your Shopping Cart ===");
            double grandTotal = 0;

            foreach (var item in cartItems)
            {
                double total = item.Product.Price * item.Quantity;
                grandTotal += total;
                Console.WriteLine($"ID: {item.ProductId} | {item.Product.Name} | Qty: {item.Quantity} | Price: {item.Product.Price}$ | Total: {total}$");
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Grand Total: {grandTotal}$");
        }

        public void UpdateCartQuantity(Models.User user)
        {
            Console.Write("Enter Product ID from cart to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                throw new Exception("Invalid Product ID!");

            var cartItem = _db.CartItems
                .Include(c => c.Product)
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if (cartItem == null) throw new Exception("Item not found in your cart!");

            Console.Write($"Enter new quantity (Available stock: {cartItem.Product.Stock}): ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity))
                throw new Exception("Invalid Product ID!");

            if(newQuantity <= 0)
            {
                _db.CartItems.Remove(cartItem);
                Console.WriteLine("Item removed from cart.");
            }
            else
            {
                if(newQuantity > cartItem.Product.Stock)
                {
                    throw new Exception("Not enough stock!");
                }

                cartItem.Quantity = newQuantity;
                Console.WriteLine("Quantity updated.");
            }
            _db.SaveChanges();
        }
        public void RemoveFromCart(Models.User user)
        {
            Console.Write("Enter Product Id to remove from cart: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
                throw new Exception("Invalid Product ID!");

            var cartItem = _db.CartItems
                .FirstOrDefault(c=>c.UserId == user.Id && c.ProductId == productId);

            if (cartItem == null) throw new Exception("Item not found in cart!");

            _db.CartItems.Remove(cartItem);
            _db.SaveChanges();
            Console.WriteLine("Product removed from cart.");
        }

        public void ClearCart(Models.User user)
        {
            var userCartItems = _db.CartItems.Where(c => c.UserId == user.Id);
            _db.CartItems.RemoveRange(userCartItems);
            _db.SaveChanges();
            Console.WriteLine("Cart cleared.");
        }



    }
}
