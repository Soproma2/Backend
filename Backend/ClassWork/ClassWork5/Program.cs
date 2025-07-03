namespace ClassWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(helloWorld());

            //string userText = Console.ReadLine();
            //Console.WriteLine(isTextPalindrom(userText));

            //int[] ar = { 1, 2, 1 };
            //Console.WriteLine(isArrayPalindrom(ar));


            //string userText2 = Console.ReadLine();
            //int num = Convert.ToInt32(Console.ReadLine());
            //print(userText2, num);

            //int[] array = { 1, 2, 123, 12, 12, 1, 34, 223 };
            //Console.WriteLine(FInd(array, 12));

        }

        static string helloWorld()
        {
            return "Hello World";
        }

        static string isTextPalindrom(string palindrom)
        {
            char[] userTextC = palindrom.ToCharArray();
            Array.Reverse(userTextC);
            string revStr = new string(userTextC);
            return palindrom == revStr ? "The string is a palindrome." : "No, it's not a palindrome.";
        }

        static bool isArrayPalindrom(int[] array)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start < end)
            {
                if (array[start] != array[end])
                {
                    return false;
                }
                start++;
                end--;
            }

            return true;

        }

        static void print(string ar, int num)
        {

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(ar);
            }
        }

        static int FInd(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    return arr[i];
                }

            }
            return 0;
        }
    }
}
