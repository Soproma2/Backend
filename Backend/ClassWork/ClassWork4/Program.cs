namespace ClassWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    int fNum;
                    Console.Write("Enter your first number: ");
                    while (!int.TryParse(Console.ReadLine(), out fNum))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer:");
                    }

                    int sNum;
                    Console.Write("Enter your second number: ");
                    while (!int.TryParse(Console.ReadLine(), out sNum))
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer:");
                    }

                    char op;
                    Console.Write("Enter operator (+, -, *, /): ");
                    while (true)
                    {
                        string input = Console.ReadLine();

                        if (input.Length == 1 && "+-*/".Contains(input))
                        {
                            op = input[0];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Operator is incorrect! Please enter one of (+, -, *, /):");
                        }
                    }



                    if (op == '+' || op == '-' || op == '*' || op == '/')
                    {
                        switch (op)
                        {
                            case '+':
                                int result1 = fNum + sNum;
                                Console.WriteLine($"{fNum} {op} {sNum} = {result1}");
                                break;
                            case '-':
                                int result2 = fNum - sNum;
                                Console.WriteLine($"{fNum} {op} {sNum} = {result2}");
                                break;
                            case '*':
                                int result3 = fNum * sNum;
                                Console.WriteLine($"{fNum} {op} {sNum} = {result3}");
                                break;
                            case '/':
                                if (sNum != 0)
                                {
                                    int result4 = fNum / sNum;
                                    Console.WriteLine($"{fNum} {op} {sNum} = {result4}");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Cannot divide by zero");
                                    break;
                                }

                        }
                    }

                    Console.Write("Close application (x=yes or other character=no): ");
                    char exitInput = Convert.ToChar(Console.ReadLine());
                    if (exitInput == 'x' || exitInput == 'X')
                    {
                        Console.WriteLine("Application closed.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
