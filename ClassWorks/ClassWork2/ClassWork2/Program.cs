namespace ClassWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1: შეამოწმეთ, არის თუ არა რიცხვი დადებითი, ნულოვანი თუ უარყოფითი
            //Console.WriteLine("Enter your number: ");
            //int number = Convert.ToInt32(Console.ReadLine());

            //if (number > 0)
            //{
            //    Console.WriteLine("The number is positive.");
            //}
            //else if (number == 0)
            //{
            //    Console.WriteLine("The number is zero.");
            //}
            //else
            //{
            //    Console.WriteLine("The number is negative.");
            //}



            //დავალება 2
            Console.WriteLine("Enter your char: ");
            char character = Convert.ToChar(Console.ReadLine());

            if(character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u' ||
               character == 'A' || character == 'E' || character == 'I' || character == 'O' || character == 'U')
            {
                Console.WriteLine("The character is a vowel.");
            }
            else
            {
                Console.WriteLine("The character is a consonant.");

            }
        }
    }
}

