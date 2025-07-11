using System.Security.Cryptography.X509Certificates;

namespace ClassWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დაწერეთ ფუნქცია რომელსაც გადავცემთ, დაბადების თარიღს და ფუნქცია დაგვიბრუნებს თუ რამდენი წლისაა ადამიანი 

            Console.WriteLine(age(new DateTime(2008, 02, 27)));
        }

        public static int age(DateTime birthtime)
        {
            DateTime dateNow = DateTime.Now;
            var age = dateNow.Year - birthtime.Year;


            if (dateNow < birthtime.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
