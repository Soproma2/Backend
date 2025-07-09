using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class2
{
    public class Shape
    {
        //შექმენი კლასი Shape პარამეტრიანი კონსტრუქტორით(name).
        public string Name { get; set; }
        public Shape(string name)
        {
            Name = name;
            Console.WriteLine($"Name: {Name}");
        }
    }
}
