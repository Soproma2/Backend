namespace HomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // დავალება 1 (კალკულატორის ვალიდაცია: კლასში აწყობილ კალკულატორზე დაადეთ ვალიდაციები, ისე რომ შეუძლებელი იყოს არასწორი ინფორმაციის შემოყვანა კონსოლიდან შესაბამის ველებში.)
            //int fNum;
            //Console.Write("Enter your first number: ");
            //while (!int.TryParse(Console.ReadLine(), out fNum))
            //{
            //    Console.WriteLine("Invalid input! Please enter a valid integer:");
            //}

            //int sNum;
            //Console.Write("Enter your second number: ");
            //while (!int.TryParse(Console.ReadLine(), out sNum))
            //{
            //    Console.WriteLine("Invalid input! Please enter a valid integer:");
            //}

            //char op;
            //Console.Write("Enter operator (+, -, *, /): ");
            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    if (input.Length == 1 && "+-*/".Contains(input))
            //    {
            //        op = input[0];
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Operator is incorrect! Please enter one of (+, -, *, /):");
            //    }
            //}



            //if (op == '+' || op == '-' || op == '*' || op == '/')
            //    {
            //        switch (op)
            //        {
            //            case '+':
            //                int result1 = fNum + sNum;
            //                Console.WriteLine($"{fNum} {op} {sNum} = {result1}");
            //                break;
            //            case '-':
            //                int result2 = fNum - sNum;
            //                Console.WriteLine($"{fNum} {op} {sNum} = {result2}");
            //                break;
            //            case '*':
            //                int result3 = fNum * sNum;
            //                Console.WriteLine($"{fNum} {op} {sNum} = {result3}");
            //                break;
            //            case '/':
            //                if(sNum != 0)
            //                {
            //                    int result4 = fNum / sNum;
            //                    Console.WriteLine($"{fNum} {op} {sNum} = {result4}");
            //                    break;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Cannot divide by zero");
            //                    break;
            //                }

            //        }
            //}




            // დავალება 2 (ლოგინის ვალიდაცია: ააწყეთ ლოგინის ფორმა სადაც მომხმარებელს სთხოვთ რომ შემოიყვანოთ email და პაროლი. თქვენი დავალებაა რომ შემოყვანილი email და პროლი იყოს ვალიდური, მაგალითად email შეიცავდეს შესაბამის სიმბოლოებს, და პაროლი შეიცავდეს დიდ/პატარა ასოებს რიცხვებს და სპეციალურ სიმბოლოებს, აპლიკაციის რეალიზება უნდა მოხდეს კონსოლში.)

            //while (true)
            //{
            //    Console.Write("Enter your email: ");
            //    string userEmail = Console.ReadLine();

            //    Console.Write("Enter your password: ");
            //    string userPassword = Console.ReadLine();


            //    if (userEmail.Length < 8 || !userEmail.Contains("@") || !userEmail.Contains("."))
            //    {
            //        Console.WriteLine("Email is incorrect. It must be at least 8 characters and contain '@' and '.'");
            //        continue;
            //    }

            //    if (!Regex.IsMatch(userPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$"))
            //    {
            //        Console.WriteLine("Password is incorrect. It must be at least 8 characters and include uppercase, lowercase, digit, and special character.");
            //        continue;
            //    }


            //    Console.WriteLine("You are logged in!");
            //    Console.WriteLine($"Your Email: {userEmail}");
            //    Console.WriteLine($"Your Password: {userPassword}");
            //    break;
            //}
        }
    }
}
