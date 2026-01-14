using Entity_Project.Enums;
using Entity_Project.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Menus
{
    internal static class MainMenu
    {
        private static readonly IAuthService _authService = new AuthService();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to Our Store ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Verify Email");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoose option: ");

                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            _authService.Login();

                            
                            if (AuthService.CurrentUser != null)
                            {
                                
                                if (AuthService.CurrentUser.Role == UserRole.ADMIN)
                                {
                                    AdminMenu.Show(AuthService.CurrentUser);
                                }
                                else
                                {
                                    UserMenu.Show(AuthService.CurrentUser);
                                }
                            }
                            break;

                        case "2":
                            _authService.Register();
                            break;

                        case "3":
                            _authService.VerifyEmail();
                            break;

                        case "4":
                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option! Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {;
                    Console.WriteLine($"\nError: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
