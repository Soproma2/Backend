using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{
    internal class Class1
    {
        public static T Custom_Max<T>(this List<T> intList) where T : IComparable<T>
        {
            T max = intList[0];

            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i].CompareTo(max) > 0)
                {
                    max = intList[i];
                }
            }

            return max;
        }
        public static T Custom_Min<T>(this List<T> intList) where T : IComparable<T>
        {
            T min = intList[0];

            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i].CompareTo(min) < 0)
                {
                    min = intList[i];
                }
            }

            return min;
        }
        public static List<T> Custom_Take<T>(this List<T> intList, int count)
        {
            List<T> result = new();

            for (int i = 0; i < count && i < intList.Count; i++)
            {
                result.Add(intList[i]);
            }

            return result;
        }
        public static List<T> Custom_Skip<T>(this List<T> intList, int count)
        {
            List<T> result = new();

            for (int i = count; i < intList.Count; i++)
            {
                result.Add(intList[i]);
            }

            return result;
        }
    }
}
