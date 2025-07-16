using ClassWork8.Class;

namespace ClassWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] result = File.ReadAllLines(@"../../../vehicles.csv");

            

            

            for (int i = 0; i < result.Length; i++)
            {
                string[] sT = result[i].Split(',');
                Car car1 = new Car(sT[0], sT[1], Convert.ToInt32(sT[2]), Convert.ToDecimal(sT[3]), sT[4], sT[5], Convert.ToInt32(sT[6]), Convert.ToInt32(sT[7]), Convert.ToInt32(sT[8]));
                Console.WriteLine($"{car1.Make}; {car1.Model}; {car1.Cylinder}; {car1.Engine}; {car1.Drive}; {car1.Transmission}; {car1.City}; {car1.Combined}; {car1.Highway}");
            }
        }
    }
}
