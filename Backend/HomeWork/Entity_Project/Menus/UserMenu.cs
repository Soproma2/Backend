using Entity_Project.Models;
using Entity_Project.Services.Auth;
using Entity_Project.Services.Cart;
using Entity_Project.Services.Order;
using Entity_Project.Services.Product;
using Entity_Project.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Menus
{
    internal static class UserMenu
    {
        private static readonly IProductService _productService = new ProductService();
        private static readonly ICartService _cartService = new CartService();
        private static readonly IOrderService _orderService = new OrderService();
        private static readonly IUserService _userService = new UserService();
        private static readonly IAuthService _authService = new AuthService();

        public static void Show(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Customer Portal - Welcome, {user.Username} ===");
                Console.WriteLine($"Current Balance: {user.Balance}$");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("1.  View All Products");
                Console.WriteLine("2.  Search Products");
                Console.WriteLine("3.  Filter by Category");
                Console.WriteLine("4.  View Product Details");
                Console.WriteLine("5.  View My Cart");
                Console.WriteLine("6.  Add to Cart");
                Console.WriteLine("7.  Remove from Cart");
                Console.WriteLine("8.  Clear cart");
                Console.WriteLine("9.  Update Cart Quantity");
                Console.WriteLine("10. Checkout (Place Order)");
                Console.WriteLine("11. View Order History");
                Console.WriteLine("12. Cancel Order");
                Console.WriteLine("13. Add Balance");
                Console.WriteLine("14. My Profile (View & Update)");
                Console.WriteLine("15. Logout");

                Console.Write("\nChoose option: ");
                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            _productService.ViewAllProducts();
                            break;
                        case "2":
                            _productService.SearchProducts();
                            break;
                        case "3":
                            _productService.FilterByCategory();
                            break;
                        case "4":
                            _productService.ViewProductDetails();
                            break;
                        case "5":
                            _cartService.ViewCart(user);
                            break;
                        case "6":
                            _cartService.AddToCart(user);
                            break;
                        case "7":
                            _cartService.RemoveFromCart(user);
                            break;
                        case "8":
                            _cartService.ClearCart(user);
                            break;
                        case "9":
                            _cartService.UpdateCartQuantity(user);
                            break;
                        case "10":
                            _orderService.Checkout(user);
                            break;
                        case "11":
                            _orderService.ViewOrderHistory(user);
                            break;
                        case "12":
                            _orderService.CancelOrder(user);
                            break;
                        case "13":
                            _userService.AddBalance(user);
                            break;
                        case "14":
                            _userService.ViewProfile(user);
                            Console.WriteLine("\nDo you want to update your profile? (y/n)");
                            if (Console.ReadLine()?.ToLower() == "y")
                                _userService.UpdateProfile(user);
                            break;
                        case "15":
                            _authService.Logout();
                            Console.WriteLine("Successfully logged out.");
                            return;
                        default:
                            Console.WriteLine("Invalid option! Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
