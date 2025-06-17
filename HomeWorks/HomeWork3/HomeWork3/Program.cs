namespace HomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            Console.Write("Enter your fNumber: ");
            int fNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your sNumber: ");
            int sNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operators (+,-,*,/): ");
            char op = Convert.ToChar(Console.ReadLine());

            if (op == '+' || op =='-' || op == '*' || op == '/')
            {
                switch (op)
                {
                    case '+':
                        int result1 = fNum + sNum;
                        Console.WriteLine($"{fNum} {op} {sNum} = {result1}");
                        break;
                }
            }
        }
    }
}
