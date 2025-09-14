namespace HomeWork20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "George", Age = 20, Grade = 85, Subject = "Mathematics" },
                new Student { Name = "Nina", Age = 19, Grade = 92, Subject = "Physics" },
                new Student { Name = "David", Age = 21, Grade = 78, Subject = "Mathematics" },
                new Student { Name = "Mariam", Age = 20, Grade = 95, Subject = "Chemistry" },
                new Student { Name = "Luke", Age = 22, Grade = 88, Subject = "Physics" },
                new Student { Name = "Anna", Age = 19, Grade = 73, Subject = "Mathematics" },
                new Student { Name = "Saba", Age = 21, Grade = 91, Subject = "Chemistry" },
                new Student { Name = "Sophia", Age = 20, Grade = 69, Subject = "Physics" },
                new Student { Name = "Alexander", Age = 23, Grade = 82, Subject = "Mathematics" },
                new Student { Name = "Emily", Age = 19, Grade = 90, Subject = "Chemistry" },
                new Student { Name = "Nicholas", Age = 21, Grade = 77, Subject = "Physics" },
                new Student { Name = "Kate", Age = 20, Grade = 94, Subject = "Mathematics" },
                new Student { Name = "Michael", Age = 22, Grade = 86, Subject = "Chemistry" },
                new Student { Name = "Helen", Age = 19, Grade = 81, Subject = "Physics" },
                new Student { Name = "Thomas", Age = 21, Grade = 75, Subject = "Mathematics" }
            };


            //შესასრულებელი ამოცანები LINQ - ის გამოყენებით:

            //იპოვეთ ყველა სტუდენტი, რომლის ქულაც 80 - ზე მეტია
            //იპოვეთ საშუალო ქულა მათემატიკაში
            //დააჯგუფეთ სტუდენტები საგნების მიხედვით
            //იპოვეთ ყველაზე ახალგაზრდა სტუდენტი

            var topS = students.Where(s=>s.Grade > 80).ToList();
            foreach(Student s in topS)
            {
                Console.WriteLine($"{s.Name} - {s.Age} - {s.Grade} - {s.Subject}");
            }
            Console.WriteLine();


            var avgMath = students.Where(s=>s.Subject == "Mathematics").Average(s=>s.Grade);
            Console.WriteLine(avgMath);
            Console.WriteLine();

            //var groupedC = students.GroupBy(s => s.Subject)
            //    .Select(s=> new
            //    {
            //        subject = s.Key,
            //        name = s.Select(s=>s.Name).ToList(),
            //        age = s.Select(s=>s.Age).ToList(),
            //        grade = s.Select(s => s.Grade).ToList()
            //    });
            //foreach(var sa in groupedC)
            //{
            //    foreach(var g  in sa)
            //    {
            //        Console.WriteLine($"{s.name} - {s.age} - {s.grade} - {s.subject}");
            //    }
            //}??????????????????????????????????????????

            var grouped = students.GroupBy(s => s.Subject);

            foreach (var group in grouped)
            {
                Console.WriteLine($"Subject: {group.Key}");
                foreach (var s in group)
                {
                    Console.WriteLine($"{s.Name} - {s.Age} - {s.Grade} - {s.Subject}");
                }
                Console.WriteLine("----------------------");
            }

            Console.WriteLine();

            var youngS = students.OrderBy(s=>s.Age).FirstOrDefault();
            Console.WriteLine($"{youngS.Name} - {youngS.Age} - {youngS.Grade} - {youngS.Subject}");


        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public string Subject { get; set; }
    }
}
