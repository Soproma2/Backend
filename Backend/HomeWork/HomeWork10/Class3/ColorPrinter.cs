using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class3
{
    internal class ColorPrinter : Printer
    {
        //შემდეგ შექმენი ColorPrinter, რომელიც ქმნის იგივე სახელის Print() მეთოდს new- ით და ბეჭდავს სხვა ტექსტს.
        public new void print()
        {
            Console.WriteLine("Printing in color...");
        }
    }
}
