using Entity_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Menus
{
    internal static class AdminMenu
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
                Console.WriteLine("5. Mark Order as Delivered");
                Console.WriteLine("6. Cancel Order");
                Console.WriteLine("7. View All Product");
                Console.WriteLine("8. Logout");
                Console.Write("Choose option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    //case "1": ProductServices.AddProduct(); break;
                    //case "2": ProductServices.UpdateProduct(); break;
                    //case "3": ProductServices.DeleteProduct(); break;
                    //case "4": OrderServices.ViewAllOrders(); break;
                    //case "5": OrderServices.MarkOrderDelivered(); break;
                    //case "6": OrderServices.AdminCancelOrder(); break;
                    //case "7": ProductServices.ViewAllProducts(); break;
                    //case "8": return;
                    //default: break;
                }
            }
        }
    }
}
