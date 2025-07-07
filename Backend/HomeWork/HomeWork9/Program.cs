using HomeWork9.BankModels;

namespace HomeWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //• შექმენით სტუდენტის კლასი,რომელსაც უნდა ჰქონდეს
            //სახელი
            //გვარი
            //ასაკი(მინიმაური უნდა იყოს 18 წელი  მაქსიმალური 50 წელი)
            //ქულა(მინიმალური უნდა იყოს 0 მაქსიმალური 100)



            //• წინა გაკვეთილში მოაცემული კლასები გადააწყეთ property-ებად(ანუ გააკეთეთ ის რაც აგიხსენით გაკვეთილზე).
            //აგრეთვე Account კლასს დაუმატეთ ფუნქციონალი სადაც მომხმარებელი შეძლებს რომ ანგარიში გაანაღოს ან შეავსოს მისთვის სასურველი თანხით.

            User Nika = new User()
            {
                FirstName = "Nikolozi",
                LastName = "Sopromadze",
                PersonalNumber = "26747580032",
                Account = new Account()
                {
                    Iban="8745987324958734856935",
                    Currency = "Gel",
                    Balance = 10000000,
                    withdraw = 10.2M,
                    deposit = 100.5M
                }
                
            };

            

            

            

            

        }
    }
}
