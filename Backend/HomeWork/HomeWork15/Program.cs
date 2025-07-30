using System;
using System.Collections.Generic;

namespace HomeWork15
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> intlist = new List<int>() { 1,1,134,12,223,441,123,12};
            Class1.Mydistinct(intlist);
            Class1.MyReverse(intlist);
            Class1.MyReverse(intlist, x => x % 2 == 0);
            Class1.MyAny(intlist, n => n > 0);
            Class1.MyAll(intlist, x => x % 2 != 0);
            Class1.MyMax(intlist);
            Class1.MyMin(intlist);
            Class1.MyTake(intlist, 3);
            Class1.MySkip(intlist, 2);


            

            
           
        }
    }
}
