namespace ClassWork11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            //List<int> newList = new List<int>();

            for (int i = 1; i < 101; i++)
            {
                list.Add(i);
            }

            //foreach(int num in list)
            //{
            //    if(num % 3 == 0 && num > 20 && num < 70)
            //    {
            //        newList.Add(num);
            //    }
            //}
            //newList.Sort((a, b) => b.CompareTo(a));

            //foreach (int num in newList)
            //{
            //    Console.WriteLine(num);
            //}


            //var linq = list.Where(n => n % 3 == 0 && n > 20 && n < 70).OrderByDescending(n=>n).ToList();

            //foreach(int num in linq)
            //{
            //    Console.WriteLine(num);
            //}


            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 2500, Stock = 10 },
                new Product { Name = "Mouse", Category = "Electronics", Price = 50, Stock = 100 },
                new Product { Name = "Keyboard", Category = "Electronics", Price = 150, Stock = 50 },
                new Product { Name = "Monitor", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Name = "Desk", Category = "Furniture", Price = 600, Stock = 15 },
                new Product { Name = "Chair", Category = "Furniture", Price = 350, Stock = 30 },
                new Product { Name = "Notebook", Category = "Stationery", Price = 5, Stock = 500 },
                new Product { Name = "Pen", Category = "Stationery", Price = 2, Stock = 1000 }
            };

            //var productLinq = products.Where(p => p.Price > 1000 && p.Stock<50).ToList();
            //foreach (var p in productLinq)
            //{
            //    Console.WriteLine($"{p.Name}, {p.Category}, {p.Price}, {p.Stock}");
            //}


            var categorylinq = products.GroupBy(n => n.Category)
                .Select(n => new { Categery = n.Key, Price = n.Select(x => x.Price).Max() });
            foreach(var p in categorylinq)
            {
                Console.WriteLine($"{p.Categery},{p.Price}");
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }   
    } 
}

