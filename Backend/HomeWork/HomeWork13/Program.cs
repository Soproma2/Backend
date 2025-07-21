using HomeWork13.Class;
using System.Globalization;

namespace HomeWork13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Currency Menu ---");
                Console.WriteLine("1. Find rate by code");
                Console.WriteLine("2. Show all rates");
                Console.WriteLine("3. Add or update currency");
                Console.WriteLine("4. Delete currency");
                Console.WriteLine("5. Save to file");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter currency code: ");
                        Class1.FindRateByCode(Console.ReadLine());
                        break;
                    case "2":
                        Class1.DisplayAllRatesSorted();
                        break;
                    case "3":
                        Class1.AddOrUpdateCurrency();
                        break;
                    case "4":
                        Class1.DeleteCurrency();
                        break;
                    case "5":
                        Class1.SaveDataToFile();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }

}

