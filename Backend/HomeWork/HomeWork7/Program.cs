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

            Console.Write("Enter Name(1): ");
            string name1 = Console.ReadLine();
            Console.Write("Enter Name(2): ");
            string name2 = Console.ReadLine();
            Console.Write("Enter Name(3): ");
            string name3 = Console.ReadLine();
            string[] names = { name1, name2, name3 };
            getNames(names, 0);
            getNames(names, 1);
            getNames(names, 2);
            Console.WriteLine();

            arrayMembers();
            Console.WriteLine();
            Console.WriteLine();


            int[] array = [10, 5, 3, 4, 18,];
            arraySort(array);
            Console.WriteLine();
            Console.WriteLine();

            arrayMin(array);
        }


        static void numbers(int i)
        {
            int[] ar = { 11, 12, 33, 44 };
            Console.WriteLine(ar[i]);
        }

        static void getNames(string[] names, int i)
        {
            Console.WriteLine(names[i]);
        }

        static void arrayMembers()
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write(ar[i] + ";");
            }
        }

        static void arraySort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        int t = array[j];
                        array[j] = array[i];
                        array[i] = t;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ";");
            }
        }

        static void arrayMin(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine(min);
        }
    }
}
