using HomeWork13.Class;
using System.Globalization;

namespace HomeWork13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.მოცემულია CSV ფაილი "exchange_rates.csv" სახელწოდებით, რომელშიც ინახება ვალუტის კოდები და კურსები:

            //2.შექმენი კონსოლის აპლიკაცია, რომელიც:
            //წაიკითხავს ამ ფაილს
            //ჩატვირთავს მონაცემებს Dictionary<string, decimal> ტიპში, სადაც Key არის ვალუტის კოდი, ხოლო Value — კურსი ლარში.

            //3.აპლიკაციას უნდა ჰქონდეს შემდეგი ფუნქციონალი:
            //მომხმარებლისგან ითხოვოს ვალუტის კოდი და დააბრუნოს შესაბამისი კურსი.
            //აჩვენოს ყველა ხელმისაწვდომი კურსი სორტირებით(დალაგებული კოდის ან კურსის მიხედვით).
            //დაამატოს ან განაახლოს ახალი ვალუტის კოდი და კურსი.
            //წაშალოს ვალუტა მისი კოდით.
            //ფაილში დაამატოს/ განაახლოს ცვლილებები.

            string[] exchange_rates = File.ReadAllLines(@"../../../exchange_rates.csv");

            Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>();
            
            foreach (string exchange_rate in exchange_rates)
            {
                string[] splitedExchangeRate = exchange_rate.Split(',');
                string currencyCode = splitedExchangeRate[0];

                if (decimal.TryParse(splitedExchangeRate[1], out decimal rate))
                {
                    exchangeRates[currencyCode] = rate;
                }
            }

            while (true)
            {
                Console.WriteLine("1. Find rate by currency code");
                Console.WriteLine("2. Show all rates (sorted by code or value)");
                Console.WriteLine("3. Add or update currency rate");
                Console.WriteLine("4. Delete currency by code");
                Console.WriteLine("5. Save changes to file");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Class1.FindRateByCode();
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
                    case "6":
                        Class1.SaveDataToFile();
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }


            }
        }
    }
}
