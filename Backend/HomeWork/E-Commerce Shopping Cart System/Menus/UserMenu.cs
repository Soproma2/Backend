using E_Commerce_Shopping_Cart_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }
        }
    }
}
