using ClassWork8.Class;
using System.Linq;

namespace ClassWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] result = File.ReadAllLines(@"../../../vehicles.csv");
            //1. ამ ფაილში არსებული თითოეული მასივის ელემენტი, გარდაქმენით მანქანის ობიექტად და დაბეჭდეთ კონსოლში +
            //2. მოძებნეთ ყველა მერსედეს ბენცი.
            //3. მოძებნეთ 10 ყველაზე ეკონომიური მანქანა.


            Car? car = null;
            string[] sT;
            List<Car> cars = new List<Car>();

            for (int i = 1; i < result.Length; i++)
            {
                sT = result[i].Split(',');
                car = new Car(sT[0], sT[1], Convert.ToInt32(sT[2]), Convert.ToDecimal(sT[3]), sT[4], sT[5], Convert.ToInt32(sT[6]), Convert.ToInt32(sT[7]), Convert.ToInt32(sT[8]));
                // Console.WriteLine($"{car.Make}; {car.Model}; {car.Cylinder}; {car.Engine}; {car.Drive}; {car.Transmission}; {car.City}; {car.Combined}; {car.Highway}");
                if (car.Make == "Mercedes-Benz")
                {
                    Console.WriteLine($"{car.Make}; {car.Model}; {car.Cylinder}; {car.Engine}; {car.Drive}; {car.Transmission}; {car.City}; {car.Combined}; {car.Highway}");
                }
                cars.Add(car);


            }
            Console.WriteLine();

            List<Car> top10 = new List<Car>();

            foreach (var c in cars)
            {
                if (top10.Count < 10)
                {
                    top10.Add(c);
                }
                else
                {
                    int minIndex = 0;
                    int minCombined = top10[0].Combined;

                    for (int i = 1; i < top10.Count; i++)
                    {
                        if (top10[i].Combined < minCombined)
                        {
                            minCombined = top10[i].Combined;
                            minIndex = i;
                        }
                    }


                    if (c.Combined > minCombined)
                    {
                        top10[minIndex] = c;
                    }
                }
            }


            top10.Sort((a, b) => b.Combined.CompareTo(a.Combined));

            foreach (var c in top10)
            {
                Console.WriteLine($"{c.Make} {c.Model} | Combined: {c.Combined} MPG");
            }



        }
    }
}
