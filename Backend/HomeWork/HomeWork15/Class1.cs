using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    internal class Class1
    {

        //🔹 1. MyDistinct(List<int> source)
        //აღწერა:
        //დაბრუნეთ ახალი სია იმ ელემენტებით, რომლებიც უნიკალურია. იგივე მნიშვნელობა სიაში არ უნდა განმეორდეს.

        //მოთხოვნები:

        //არ გამოიყენოთ HashSet.

        //შედეგები დააბრუნეთ იმ მიმდევრობით, როგორც წყაროშია.


        public static List<int> Mydistinct(List<int> source)
        {
            List <int> list = new();

            for (int i = 0; i < source.Count; i++)
            {
                if (!list.Contains(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            return list;
        }




        //🔹 2. MyReverse(List<int> source)
        //აღწერა:
        //დაბრუნეთ სია შებრუნებული მიმდევრობით.

        //მაგ: [1, 2, 3] → [3, 2, 1]


        public static List<int> MyReverse(List<int> source)
        {
            List <int> list = new();

            for (int i = source.Count - 1; i >= 0; i--)
            {
                list.Add(source[i]);
            }

            return list;
        }



        //🔹 3. MyReverse(List<int> source, Func<int, bool> predicate)
        //აღწერა:
        //დაბრუნეთ ახალი სია, რომელიც შეიცავს მხოლოდ იმ ელემენტებს, რომლებიც აკმაყოფილებენ პირობას (predicate) და არის შებრუნებული მიმდევრობით.

        //მაგ: [1, 2, 3, 4] და x => x % 2 == 0 → [4, 2]


        public static List<int> MyReverse(List<int> source, Func<int, bool> predicate)
        {
            List <int> list = new();

            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            return list;
        }
    }
}
