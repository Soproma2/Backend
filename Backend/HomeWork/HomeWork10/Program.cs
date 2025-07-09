using HomeWork10.Class1;
using HomeWork10.Class2;
using HomeWork10.Class3;
using HomeWork10.Class4;
using HomeWork10.Class5;
using System.Drawing;
using System.Xml.Linq;

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
            Console.WriteLine();

            //-----------------------------------------------------------------------------------------------------------------


            //✅ სავარჯიშო 2: კონსტრუქტორების მემკვიდრეობა — "Shape & Rectangle"
            //ამოცანა:
            //შექმენი კლასი Shape პარამეტრიანი კონსტრუქტორით(name).
            //შემდეგ შექმენი Rectangle კლასი, რომელიც გამოძახებს მშობლის კონსტრუქტორს base(name) - ით.

            
            Rect rect1 = new Rect("Myrect", 20, 10);
            Console.WriteLine();

            //------------------------------------------------------------------------------------------------------------------


            //✅ სავარჯიშო 4: სახელის დამალვა(new) — "Printer & ColorPrinter"
            //ამოცანა:
            //შექმენი Printer კლასი მეთოდით Print().
            //შემდეგ შექმენი ColorPrinter, რომელიც ქმნის იგივე სახელის Print() მეთოდს new- ით და ბეჭდავს სხვა ტექსტს.
            //დავალება:
            //გამოიძახე Print() ორივე ტიპით(Printer და ColorPrinter) და დააკვირდი შედეგს.

            
            Printer printer = new Printer();
            printer.print();

            ColorPrinter colorPrinter = new ColorPrinter();
            colorPrinter.print();
            Console.WriteLine();

            //------------------------------------------------------------------------------------------------------------------


            //✅ სავარჯიშო 5: base საკვანძო სიტყვა — "Animal & Dog"
            //ამოცანა:
            //შექმენი Animal კლასი, რომელშიც იქნება MakeSound() მეთოდი.
            //შემდეგ Dog კლასი რომელიც override-ით შეცვლის და გამოიძახებს base.MakeSound().

            //უნდა დაბეჭდოს:
            //Animal makes sound
            //Dog barks


            Animal animal = new Animal();
            animal.MakeSound();

            Dog dog = new Dog();
            dog.MakeSound();
            Console.WriteLine();

            //-------------------------------------------------------------------------------------------------------------------


            //✅ სავარჯიშო 6: საკუთარი გამონაკლისის კლასი — "InvalidAgeException"
            //ამოცანა:
            //შექმენი ახალი კლასი InvalidAgeException, რომელიც მემკვიდრეობით მიიღებს Exception - ს.
            //დაწერე მეთოდი RegisterUser(int age), რომელიც age< 18 შემთხვევაში აგდებს ამ გამონაკლისს.


            try
            {
                Console.Write("Enter Your age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                RegiserUser(age);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RegiserUser(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException();
            }
        }
    }
}
