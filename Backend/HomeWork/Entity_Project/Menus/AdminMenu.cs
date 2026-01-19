using Entity_Project.Models;
using Entity_Project.Services.Auth;
using Entity_Project.Services.Order;
using Entity_Project.Services.Product;


namespace Entity_Project.Menus
{
    internal static class AdminMenu
    {
        private static readonly IProductService _productService = new ProductService();
        private static readonly IOrderService _orderService = new OrderService();
        private static readonly IAuthService _authService = new AuthService();

        public static void Show(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Admin Panel - Welcome, {user.Username} ===");

                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View All Orders");
                Console.WriteLine("5. Mark Order as Delivered");
                Console.WriteLine("6. Cancel Order");
                Console.WriteLine("7. View All Products");
                Console.WriteLine("8. View Order Details");
                Console.WriteLine("9. Logout");
                Console.Write("\nChoose option: ");

                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            _productService.AddProduct();
                            break;
                        case "2":
                            _productService.UpdateProduct();
                            break;
                        case "3":
                            _productService.DeleteProduct();
                            break;
                        case "4":
                            _orderService.ViewAllOrders();
                            break;
                        case "5":
                            _orderService.MarkOrderDelivered();
                            break;
                        case "6":
                            _orderService.AdminCancelOrder();
                            break;
                        case "7":
                            _productService.ViewAllProducts();
                            break;
                        case "8":
                            _orderService.ViewOrderDetails();
                            break;
                        case "9":
                            Console.WriteLine("Logging out from Admin Panel...");
                            _authService.Logout();
                            return;
                        default:
                            Console.WriteLine("Invalid option, try again.");
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
