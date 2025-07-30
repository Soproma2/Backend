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

            for (int i = source.Count - 1; i >= 0; i--)
            {
                if (predicate(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            return list;
        }



        //🔹 4. MyAny(List<int> source, Func<int, bool> predicate)
        //აღწერა:
        //დააბრუნეთ true, თუ არსებობს მინიმუმ ერთი ელემენტი, რომელიც აკმაყოფილებს მოცემულ პირობას.


        public static bool MyAny(List<int> source, Func<int, bool> predicate)
        {
            for (int i = 0;i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    return true;
                }
            }

            return false; 
        }


        //🔹 5. MyAll(List<int> source, Func<int, bool> predicate)
        //აღწერა:
        //დააბრუნეთ true, თუ ყველა ელემენტი აკმაყოფილებს მოცემულ პირობას.

        public static bool MyAll(List<int> source, Func<int, bool> predicate)
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (!predicate(source[i]))
                {
                    return false;
                }
            }

            return true;
        }


        //🔹 6. MyMax(List<int> source)
        //აღწერა:
        //დააბრუნეთ სიაში არსებული მაქსიმალური მნიშვნელობა.

        //შენიშვნა:
        //თუ სია ცარიელია, უნდა ისროლოს გამონაკლისი (ArgumentException).

        public static int MyMax(List<int> source)
        {
            if (source.Count == 0)
            {
                throw new ArgumentException("სია ცარიელია");
            }

            int max = source[0];
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                }
            }

            return max;
        }


        //🔹 7. MyMin(List<int> source)
        //აღწერა:
        //დააბრუნეთ სიაში არსებული მინიმალური მნიშვნელობა.

        //შენიშვნა:
        //თუ სია ცარიელია, უნდა ისროლოს გამონაკლისი (ArgumentException).


        public static int MyMin(List<int> source)
        {
            if (source.Count == 0)
            {
                throw new ArgumentException("სია ცარიელია");
            }

            int min = source[0];
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i] < min)
                {
                    min = source[i];
                }
            }

            return min;
        }


        //🔹 8. MyTake(List<int> source, int count)
        //აღწერა:
        //დააბრუნეთ სია, რომელიც შეიცავს მხოლოდ პირველ count რაოდენობის ელემენტს.

        //მაგ: MyTake([1,2,3,4,5], 3) → [1,2,3]


        public static List<int> MyTake(List<int> source, int count)
        {
            List<int> list = new();
            for (int i = 0; i < count && i < source.Count; i++)
            {
                list.Add(source[i]);
            }

            return list;
        }


        //🔹 9. MySkip(List<int> source, int count)
        //აღწერა:
        //დაბრუნეთ სია, რომელიც შეიცავს ყველა იმ ელემენტს, რაც იწყება count ინდექსიდან.

        //მაგ: MySkip([1,2,3,4,5], 2) → [3,4,5]🔹


        public static List<int> MySkip(List<int> source, int count)
        {
            List<int> list = new();
            for (int i = count; i < source.Count; i++)
            {
                list.Add(source[i]);
            }

            return list;
        }
    }
}
