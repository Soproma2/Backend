using System.ComponentModel.DataAnnotations;

namespace HomeWork6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, };
            //დავალება 1 (დაწერეთ კოდი რომელიც შეაჯამებს მასივის ყველა ელემენტს)
            int sum = default;
            for(int i=0; i<ar.Length; i++)
            {
                sum += ar[i];
            }
            Console.WriteLine(sum);



            //დავალება 2 (დაწერეთ კოდი რომელიც მოძებმის მასივის ზომას length - ის გამოყენების გარეშე)
            int length = 0;
            foreach(int i in ar)
            {
                length++;
            }
            Console.WriteLine(length);



            //დავალება 3 (დაწერეთ კოდი რომელიც დაბეჭდავს მასივს უკუღმა)
            for (int i = ar.Length-1; i >=0; i--)
            {
                Console.WriteLine(ar[i]);
            }



            //დავალება 4 (დაწერეთ კოდი რომელიც მასივის ყველა ელემენტს გადააკოპირებს მერე მასივში)

        }
    }
}
