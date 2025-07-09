using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class2
{
    public class Rect : Shape
    {
        //შემდეგ შექმენი Rectangle კლასი, რომელიც გამოძახებს მშობლის კონსტრუქტორს base(name) - ით.

        public int Width { get; set; }
        public int Height { get; set; }

        public Rect(string name, int width, int height) : base(name)
        {
            Width = width;
            Height = height;
            Console.WriteLine($"Width: {Width}, Height: {Height}");
        }
    }
}
