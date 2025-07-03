namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, };
            //დავალება 1 (დაწერეთ კოდი რომელიც შეაჯამებს მასივის ყველა ელემენტს)
            int sum = default;
            for (int i = 0; i < ar.Length; i++)
            {
                sum += ar[i];
            }
            Console.WriteLine(sum);
            Console.WriteLine();


            //დავალება 2 (დაწერეთ კოდი რომელიც მოძებმის მასივის ზომას length - ის გამოყენების გარეშე)
            int length = 0;
            foreach (int i in ar)
            {
                length++;
            }
            Console.WriteLine(length);
            Console.WriteLine();


            //დავალება 3 (დაწერეთ კოდი რომელიც დაბეჭდავს მასივს უკუღმა)
            for (int i = ar.Length - 1; i >= 0; i--)
            {
                Console.Write(ar[i] + ";");
            }
            Console.WriteLine();
            Console.WriteLine();



            //დავალება 4 (დაწერეთ კოდი რომელიც მასივის ყველა ელემენტს გადააკოპირებს მეორე მასივში)
            int[] ar2 = new int[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                ar2[i] = ar[i];
            }
            foreach (int num in ar2)
            {
                Console.Write(num + ";");
            }
            Console.WriteLine();
            Console.WriteLine();


            //დავალება 5 (დაწერეთ კოდი რომელიც მოძებნის მასივის უნიკალურ ელემენტებს)
            for (int i = 0; i < ar.Length; i++)
            {
                bool unique = true;
                for (int j = 0; j < ar.Length; j++)
                {
                    if (i != j && ar[i] == ar[j])
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique)
                {
                    Console.Write(ar[i] + ";");
                }
            }
            Console.WriteLine();
        }
    }
}
