using HomeWork23.Models;
using HomeWork23.Services;

namespace HomeWork23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 2 - შოპის სისიტემა

            //1.შექმენით მარტივი რეგისტრაცია სახელით და ელ.ფოსტით.
            //2.შექმენით პროდუცტების ლისტი და გააკეთეთ ყიდვის ფუნქცინოალი.
            //3.ყიდვის დროს უნდა შეიქმნას ფაილი რომელიც იქნება მომხმარებლის სახელით
            //   მაგალითად: gio.txt, ani.txt და ასე შემდეგ.
            //4.ფაილში უნდა ეწეროს იმ პროდუქტების ინფორმაცია რაც ამ ადამიანმა
            //   შეიძინა.
            //5  სურვილის შემთხვევაში(თუ მოასწრებთ) ააწყეთ მენუს სისტემა,
            //   სადაც იქნება როგორც რეგისტრაცია ასევე გასვლა და ახალი მომხმარებლით
            //   რეგისტრაციის გავლა რათა კონსოლის გამორთვის გარეშე შეძლოს სხვადასხვა
            //   მომხმარებლის დარეგისტრირება და პროდუქტების შეძენა.

            UserServices userService = new UserServices();
            ShopServices shopService = new ShopServices();

            User currentUser = null;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Buy a product");
                Console.WriteLine("3. Switch user");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        currentUser = userService.RegisterUser();
                        Console.WriteLine($"User {currentUser.Name} has been registered!");
                        break;

                    case "2":
                        if (currentUser != null)
                            shopService.BuyProduct(currentUser);
                        else
                            Console.WriteLine("Please register first!");
                        break;

                    case "3":
                        currentUser = null;
                        Console.WriteLine("User has been logged out.");
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Program has ended.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

        }
    }
}
