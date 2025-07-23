namespace ClassWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. დაწერეთ მეთოდი Custom_Where --> მეთოდმა უნდა მიიღოს int ლისტი და დააბრუნოს ყველა შესაძლო შედეგი, გადაცემული პირობის მიხედვით.
            //2. დაწერეთ მეთოდი Custom_FirstIndex --> მეთოდმა უნდა მიიღოს int ლისტი და დააბრუნოს პირობის მიხედვით გადაცემული შესაბამისი პირველივე ელემენტის ინდექსი.
            //3. დაწერეთ მეთოდი Custom_LastIndex --> მეთოდმა უნდა მიიღოს int ლისტი და დააბრუნოს პირობის მიხედვით გადაცემული შესაბამისი ბოლო ელემენტის ინდექსი.

            List<int> intList = new() { 1, -11, 2, 21, -30, 30, 7, 7 };
            var result = Custom_FirstIndex(intList, n => n == 30);
        }

        public static void Custom_Where(List<int> list, Func<int, int[]> predicate)
        {

        }

        public static int Custom_FirstIndex(List<int> list, Func<int, bool> func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (func(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Custom_LastIndex(List<int> list, Func<int, bool> func)
        {
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if (func(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
