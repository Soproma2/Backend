namespace ClassWork10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<int> OddNumbers()
            //{
            //    for(int i =1;  i < 20; i++)
            //    {
            //        if (i % 2 != 0)
            //            yield return i;
            //    }
            //}

            //foreach(int i in OddNumbers())
            //{
            //    Console.WriteLine(i);
            //}



            //IEnumerable<int> MyRange(int start, int end, int step)
            //{
            //    for(int i = start; i <= end; i=i+step)
            //    {
            //        yield return i;
            //    }
            //}

            //foreach(var num in MyRange(10, 0, -2))
            //{
            //    Console.WriteLine(num);
            //}


            //IEnumerable<int> MyRange(int start, int end, int step)
            //{
            //    if (step == 0)
            //    {
            //         Console.WriteLine("Step cannot be zero");
            //    }else if (step > 0)
            //    {
            //    for (int i = start; i <= end; i += step)
            //            yield return i;
            //    }
            //    else
            //    {
            //        for (int i = start; i >= end; i += step)
            //            yield return i;
            //    }
            //}


            //foreach (var num in MyRange(10, 0, -2))
            //{
            //    Console.WriteLine(num);
            //}



            IEnumerable<string> GetLongWords(List<string> words)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i].Length < 5)
                    {
                        yield return words[i];
                    }
                }
            }


            List<string> words = new List<string>();
            words.Add("manqana");
            words.Add("avtobusi");
            words.Add("moto");


            foreach (string word in GetLongWords(words))
            {
                Console.WriteLine(word);
            }
        }
    }
}
