using Entity_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Menus
{
    internal static class MainMenu
    {
        public static void Show()
        {
            Console.WriteLine("\n1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                //case "1":
                //    var user = AuthSevices.Login();
                //    if (user != null)
                //    {
                //        if (user.Role == UserRole.ADMIN)
                //        {
                //            AdminMenu.Show(user);
                //        }
                //        else
                //        {
                //            UserMenu.Show(user);
                //        }
                //    }
                //    break;
                //case "2":
                //    AuthSevices.Register();
                //    break;
                //case "3":
                //    Environment.Exit(0);
                //    break;
                //default:
                //    Console.WriteLine("Invalid option!");
                //    break;
            }
        }
    }
}
