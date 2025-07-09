using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class4
{
    internal class Dog : Animal
    {
        //შემდეგ Dog კლასი რომელიც override-ით შეცვლის და გამოიძახებს base.MakeSound().
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }
}
