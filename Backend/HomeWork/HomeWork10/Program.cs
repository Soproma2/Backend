using HomeWork10.Class1;

namespace HomeWork10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //✅ სავარჯიშო 1: მემკვიდრეობა — "Transport" კლასი
            //ამოცანა:
            //შექმენი მშობელი კლასი Transport, რომელსაც ექნება მეთოდი Move() და ველი Speed.
            //შემდეგ შექმენი შვილობილი კლასი Car, რომელსაც ექნება დამატებით FuelType ველი და Drive() მეთოდი.
            //შექმენით ობიექტები ამ ტიპების მიხედვით.


            Car car1 = new Car();
            car1.Speed = 60.0;
            car1.FuelType = "gasoline";
            car1.Drive();
            car1.Move();

            //-----------------------------------------------------------------------------------------------------------------




        }
    }
}
