namespace HomeWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    while (true)
                    {
                        int fNum;
                        Console.Write("Enter your first number: ");
                        while (!int.TryParse(Console.ReadLine(), out fNum))
                        {
                            throw new Exception("Invalid input! Please enter a valid integer");
                        }

                        int sNum;
                        Console.Write("Enter your second number: ");
                        while (!int.TryParse(Console.ReadLine(), out sNum))
                        {
                            throw new Exception("Invalid input! Please enter a valid integer");
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
                                throw new Exception("Operator is incorrect! Please enter one of (+, -, *, /)");
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
                                    if (sNum == 0)
                                    {
                                        throw new DivideByZeroException("Cannot divide by zero!");
                                    }
                                    int result4 = fNum / sNum;
                                    Console.WriteLine($"{fNum} {op} {sNum} = {result4}");
                                    break;
                                default:
                                    throw new Exception("Unknown operator!");
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

                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Let's try again.");
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }
}
