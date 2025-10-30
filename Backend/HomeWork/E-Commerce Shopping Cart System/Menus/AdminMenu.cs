using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Menus
{
    public static class AdminMenu
    {
        public static void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"\nAdmin Panel - Welcome {user.Username}");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View All Orders");
                Console.WriteLine("5. Logout");
                Console.Write("Choose option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1": ProductServices.AddProduct(); break;
                    case "2": ProductServices.UpdateProduct(); break;
                    case "3": ProductServices.DeleteProduct(); break;
                    case "4": OrderServices.ViewAllOrders(); break;
                    case "5": AuthSevices.Logout(); break;
                    default: break;
                }
            }
        }
    }
}
