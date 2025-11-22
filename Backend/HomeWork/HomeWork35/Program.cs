using HomeWork35.Services;

UserProductService service = new UserProductService();

while (true)
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1. Create User");
    Console.WriteLine("2. Create Product");
    Console.WriteLine("3. Add Product to User (UserProduct)");
    Console.WriteLine("4. Show All Users");
    Console.WriteLine("5. Show User by Id (with Products)");
    Console.WriteLine("6. Show All Products");
    Console.WriteLine("7. Show Product by Id (with Users)");
    Console.WriteLine("0. Exit");
    Console.Write("Choose option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            service.CreateUser();
            break;

        case "2":
            service.CreateProduct();
            break;

        case "3":
            service.UserProduct();
            break;

        case "4":
            service.ShowUsers();
            break;

        case "5":
            service.ShowUser();
            break;

        case "6":
            service.ShowProducts();
            break;

        case "7":
            service.ShowProduct();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}