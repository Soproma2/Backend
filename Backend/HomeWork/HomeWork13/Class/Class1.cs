using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13.Class
{
    public class Class1
    {
        private static readonly string filePath = @"../../../exchange_rates.csv";
        private static Dictionary<string, decimal> currencyRates = new Dictionary<string, decimal>();

        // Load data when the class is first used
        static Class1()
        {
            LoadDataFromFile();
        }

        public static void FindRateByCode(string code)
        {
            if (currencyRates.TryGetValue(code.ToUpper(), out decimal rate))
            {
                Console.WriteLine($"Rate for {code.ToUpper()} is {rate}");
            }
            else
            {
                Console.WriteLine("Currency code not found.");
            }
        }

        public static void DisplayAllRatesSorted()
        {
            Console.WriteLine("All available currency rates (sorted by code):");
            foreach (var pair in currencyRates.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        public static void AddOrUpdateCurrency()
        {
            Console.Write("Enter currency code: ");
            string code = Console.ReadLine().ToUpper();

            Console.Write("Enter rate: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal rate))
            {
                currencyRates[code] = rate;
                Console.WriteLine("Currency added or updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid rate format.");
            }
        }

        public static void DeleteCurrency()
        {
            Console.Write("Enter the currency code to delete: ");
            string code = Console.ReadLine().ToUpper();

            if (currencyRates.Remove(code))
            {
                Console.WriteLine("Currency deleted successfully.");
            }
            else
            {
                Console.WriteLine("Currency code not found.");
            }
        }

        public static void SaveDataToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var pair in currencyRates)
                    {
                        writer.WriteLine($"{pair.Key},{pair.Value}");
                    }
                }
                Console.WriteLine("Data saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        private static void LoadDataFromFile()
        {
            if (!File.Exists(filePath)) return;

            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal rate))
                    {
                        currencyRates[parts[0].ToUpper()] = rate;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
    }

}

