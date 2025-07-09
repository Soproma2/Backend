using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class1
{
    internal class Transport
    {
        //შექმენი მშობელი კლასი Transport, რომელსაც ექნება მეთოდი Move() და ველი Speed.
        public double Speed { get; set; }
        public void Move()
        {
            Console.WriteLine($"Transport is moving at speed {Speed} km/h.");
        }
    }
}
