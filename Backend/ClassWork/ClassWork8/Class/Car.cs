using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8.Class
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Cylinder { get; set; }
        public decimal Engine { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public int City { get; set; }
        public int Combined { get; set; }
        public int Highway { get; set; }

        public Car(string Make, string Model, int Cylinder, decimal Engine,string Drive,
        string Transmission, int City, int Combined, int Highway)
        {
            this.Make = Make;
            this.Model = Model;
            this.Cylinder = Cylinder;
            this.Engine = Engine;
            this.Drive = Drive;
            this.Transmission = Transmission;
            this.City = City;
            this.Combined = Combined;
            this.Highway = Highway;
        }

    }
}
