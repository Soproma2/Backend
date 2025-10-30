using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Menus
{
    public static class UserMenu
    {
        public static void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome {user.Username} - Balance: {user.Balance}$");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Search Products");
                Console.WriteLine("3. Filter by Category");
                Console.WriteLine("4. View Product Details");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Add to Cart");
                Console.WriteLine("7. Remove from Cart");
                Console.WriteLine("8. Update Cart Quantity");
                Console.WriteLine("9. Checkout");
                Console.WriteLine("10. My orders");
                Console.WriteLine("11. Cancel Order");
                Console.WriteLine("12. Add Balance");
                Console.WriteLine("13. My Profile");
                Console.WriteLine("14. Logout");
                Console.Write("Choose option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1": ProductServices.ViewAllProducts(); break;
                    case "2": ProductServices.SearchProducts(); break;
                    case "3": ProductServices.FilterByCategory(); break;
                    case "4": ProductServices.ViewProductDetails(); break;
                    case "5": CartServices.ViewCart(user); break;
                    case "6": CartServices.AddToCart(user); break;
                    case "7": CartServices.RemoveFromCart(user); break;
                    case "8": CartServices.UpdateCartQuantity(user); break;
                    case "9": OrderServices.Checkout(user); break;
                    case "10": OrderServices.ViewOrderHistory(user); break;
                    case "11": OrderServices.CancelOrder(user); break;
                    case "12": UserServices.AddBalance(user); break;
                    case "13": UserServices.ViewProfile(user); break;
                    case "14": return;
                    default: Console.WriteLine("Invalid option!"); break;
                }
            }
        }
    }
}
