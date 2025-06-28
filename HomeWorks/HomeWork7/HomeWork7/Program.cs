namespace HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            numbers(0);
            numbers(1);
            numbers(2);
            numbers(3);
            Console.WriteLine();
            getNames(0);
            getNames(1);
            getNames(2);
        }


        static void numbers(int i)
        {
            int[] ar = { 11, 12, 33, 44 };
            Console.WriteLine(ar[i]);
        }

        static void getNames(int i)
        {
            Console.WriteLine("Enter Name(1): ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter Name(2): ");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter Name(3): ");
            string name3 = Console.ReadLine();
            string[] names = { name1, name2, name3 };
            Console.WriteLine(names[i]);
        }
    }
}
