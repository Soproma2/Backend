using HomeWork22.Services;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1 - მომხმარებლის რეგისტრაციის სისტემა.

            //1.კონსოლში მომხმარებელმა უნდა ემოიყვანოს ელ.ფოსტა, სახელი და პაროლი.
            //2.ეს ყველაფერი უნდა ჩაიწეროს users-ფაილში.
            //3.ელ.ფოსტა უნდა იყოს უნიკალური ანუ ერთიდა იმავე ელ.ფოსტა არ უნდ
            //   იყოს გამოყენებული რაც გულისხმობს იმას: თუ ვინემ ცდის უკვე არსებული
            //   ელ.ფოსტით შემოსვლას უნდა აჩვენოს რომ ეს ელ.ფოსტა უკვე
            //   გამოყენებულია.
            //4.დამატებით ჩვენ უნდა შეგვეძლოს ამ ინფომრაციის ნახვა, ანუ კონსოლში უნდა
            //   ვნახულობდე რა წერია users.txt - ში.



            while (true)
            {
                Console.WriteLine("--MENU--");
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Show users");
                Console.WriteLine("0.Exit");
                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                if (choice == "1") Auth.RegisterUser();
                else if (choice == "2") Auth.ShowUsers();
                else if (choice == "0") break;
                else Console.WriteLine("Invalid choice!");
            }
        }
    }
}
