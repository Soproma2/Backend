namespace HomeWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	საშინაო: დაწერეთ ანგარიშის კლასი, რომელსაც ექნება
            //•	ანგარიშის ნომერი(22 ნიშნა)
            //•	ვალუტა(სამნიშნა)
            //•	ბალანსი(არ უნდა იყოს უარყოფითი)

            //•	დაწერეთ კლიენტის კლასი, რომელსაც ექნება
            //•	სახელი
            //•	გვარი
            //•	პირადი ნომერი(11 ნიშნა)
            //•	ანგარიში

            //მოახდინეთ თქვენს მიერ შექმნილი კლასების დემონსტრირება კონსოლში.

            Account nikaAccount = new Account("1231512456233123123122","GEL", 1000000000);
            User user = new User("Nikolozi", "Sopromadze", "23452341222", nikaAccount);


            Console.WriteLine($"{user.firstName}'s Profile");
            Console.WriteLine($"Firstname: {user.firstName}");
            Console.WriteLine($"Lastname: {user.lastName}");
            Console.WriteLine($"Personal Number: {user.personalNumber}");
            Console.WriteLine($"Account Number: {user.account.accNumber}");
            Console.WriteLine($"Currency: {user.account.currency}");
            Console.WriteLine($"Balance: {user.account.balance}");
        }
    }
}
