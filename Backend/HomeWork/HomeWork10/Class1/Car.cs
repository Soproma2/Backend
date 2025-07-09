using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class1
{
    internal class Car : Transport
    {
        //შემდეგ შექმენი შვილობილი კლასი Car, რომელსაც ექნება დამატებით FuelType ველი და Drive() მეთოდი.
        public string FuelType { get; set; }

        public void Drive()
        {
            Console.WriteLine($"Car is driving with {FuelType} fuel.");
        }
    }
}
