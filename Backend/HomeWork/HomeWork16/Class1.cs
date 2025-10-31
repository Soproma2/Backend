using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16
{
    // Changed from 'internal class Class1' to 'public static class Class1'
    public static class Class1
    {
        public static T Custom_FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }
        public static T Custom_LastOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            T result = default;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result = item;
                }
            }

            return result;
        }
        public static IEnumerable<TDestination> Custom_Select<TSource, TDestination>(this IEnumerable<TSource> source, Func<TSource, TDestination> selector)
        {
            List<TDestination> result = new();

            foreach (var item in source)
            {
                result.Add(selector(item));
            }

            return result;
        }
        public static void Custom_Foreach<T>(this IEnumerable<T> source)
        {
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        public static IEnumerable<T> Custom_Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
        public static int Custom_FirstIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int i = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return i;
                }

                i++;
            }

            return -1;
        }
        public static int Custom_LastIndex<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int i = 0;
            int result = -1;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result = i;
                }

                i++;
            }

            return result;
        }
        public static IList<T> Custom_OrderBy<T>(this IList<T> intList, Func<T, T, bool> compareFunction)
        {
            for (int i = 0; i < intList.Count - 1; i++)
            {
                for (int j = i + 1; j < intList.Count; j++)
                {
                    if (compareFunction(intList[j], intList[i]))
                    {
                        T temp = intList[j];
                        intList[j] = intList[i];
                        intList[i] = temp;
                    }
                }
            }

            return intList;
        }
        public static int Custom_Sum(this IEnumerable<int> source)
        {
            int sum = 0;

            foreach (int item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static int Custom_Sum(this IEnumerable<int> source, Predicate<int> predicate)
        {
            int sum = 0;

            foreach (int item in source)
            {
                if (predicate(item))
                {
                    sum += item;
                }
            }

            return sum;
        }
        public static int Custom_Count<T>(this IEnumerable<T> source)
        {
            int count = 0;

            foreach (var item in source)
            {
                count++;
            }

            return count;
        }
        public static int Custom_Count<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int count = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }
        public static IEnumerable<T> Custom_Distinct<T>(this IEnumerable<T> source)
        {
            HashSet<T> set = new();

            foreach (var item in source)
            {
                set.Add(item);
            }

            return set;
        }
        public static IEnumerable<T> Custom_Reverse<T>(this IEnumerable<T> source)
        {
            Stack<T> stack = new();

            foreach (var item in source)
            {
                stack.Push(item);
            }

            return stack;
        }
        public static IEnumerable<T> Custom_Reverse<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Stack<T> stack = new();

            foreach (var item in source)
            {
                if (predicate(item))
                    stack.Push(item);
            }

            return stack;
        }
        public static bool Custom_Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool Custom_All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }




        //გადასაკეთებელი !!!!
        public static int Custom_Max(IEnumerable<int> intList)
        {
            int max = intList.First();

            foreach (int num in intList)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }
        public static int Custom_Min(IEnumerable<int> intList)
        {
            int min = intList.First();

            foreach (int num in intList)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
        public static IEnumerable<int> Custom_Take(IEnumerable<int> intList, int count)
        {
            List<int> result = new();
            int taken = 0;

            foreach (var item in intList)
            {
                if (taken >= count)
                    break;

                result.Add(item);
                taken++;
            }

            return result;
        }
        public static List<int> Custom_Skip(List<int> intList, int count)
        {
            List<int> result = new();

            int skipped = 0;

            foreach (var item in intList)
            {
                if (skipped < count)
                {
                    skipped++;
                    continue;
                }

                result.Add(item);
            }

            return result;
        }
    }
}
