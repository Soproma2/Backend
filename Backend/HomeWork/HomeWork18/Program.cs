namespace HomeWork18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1
            //List<Student> students = new List<Student>
            //{
            //    new Student { Id = 1, Username = "nika01", Age = 18, Grade = 85 },
            //    new Student { Id = 2, Username = "mari02", Age = 15, Grade = 90 },
            //    new Student { Id = 3, Username = "giorgi03", Age = 20, Grade = 45 },
            //    new Student { Id = 4, Username = "ana04", Age = 18, Grade = 88 },
            //    new Student { Id = 5, Username = "dato05", Age = 21, Grade = 92 },
            //    new Student { Id = 6, Username = "salome06", Age = 19, Grade = 81 },
            //    new Student { Id = 7, Username = "luka07", Age = 20, Grade = 79 },
            //    new Student { Id = 8, Username = "elene08", Age = 22, Grade = 95 },
            //    new Student { Id = 9, Username = "sandro09", Age = 18, Grade = 70 },
            //    new Student { Id = 10, Username = "tako10", Age = 19, Grade = 89 },
            //    new Student { Id = 11, Username = "levani11", Age = 20, Grade = 73 },
            //    new Student { Id = 12, Username = "nino12", Age = 18, Grade = 84 },
            //    new Student { Id = 13, Username = "irakli13", Age = 22, Grade = 91 },
            //    new Student { Id = 14, Username = "keti14", Age = 21, Grade = 87 },
            //    new Student { Id = 15, Username = "alex15", Age = 19, Grade = 42 },
            //    new Student { Id = 16, Username = "saba16", Age = 15, Grade = 93 },
            //    new Student { Id = 17, Username = "lia17", Age = 20, Grade = 86 },
            //    new Student { Id = 18, Username = "vano18", Age = 21, Grade = 74 },
            //    new Student { Id = 19, Username = "eka19", Age = 22, Grade = 82 },
            //    new Student { Id = 20, Username = "gio20", Age = 19, Grade = 80 },
            //    new Student { Id = 21, Username = "mzia21", Age = 14, Grade = 96 },
            //    new Student { Id = 22, Username = "nana22", Age = 20, Grade = 72 },
            //    new Student { Id = 23, Username = "dato23", Age = 21, Grade = 85 },
            //    new Student { Id = 24, Username = "sopo24", Age = 19, Grade = 78 },
            //    new Student { Id = 25, Username = "temo25", Age = 22, Grade = 90 },
            //    new Student { Id = 26, Username = "mako26", Age = 18, Grade = 83 },
            //    new Student { Id = 27, Username = "giorgi27", Age = 20, Grade = 76 },
            //    new Student { Id = 28, Username = "lali28", Age = 21, Grade = 88 },
            //    new Student { Id = 29, Username = "irina29", Age = 22, Grade = 94 },
            //    new Student { Id = 30, Username = "nika30", Age = 19, Grade = 97 },
            //};

            //var top10 = students.OrderByDescending(x => x.Grade).Take(10);
            //foreach (Student s in top10)
            //{
            //    Console.WriteLine($"{s.Id}: {s.Username}, Age:{s.Age}, Grade: {s.Grade}");
            //}
            //Console.WriteLine();


            //var failedStudents = students.Where(x => x.Grade < 51);
            //foreach (Student s in failedStudents)
            //{
            //    Console.WriteLine($"{s.Id}: {s.Username}, Age:{s.Age},Grade: {s.Grade}");
            //}
            //Console.WriteLine();


            //var top10_Age = students.Where(x => x.Age > 16).OrderByDescending(x => x.Grade).Take(10);
            //foreach (Student s in top10_Age)
            //{
            //    Console.WriteLine($"{s.Id}: {s.Username}, Age:{s.Age}, Grade: {s.Grade}");
            //}





            //დავალება2
            //List<Order> orders = new List<Order>
            //{
            //    new Order { OrderDate = new DateTime(2024,1,5),  CustomerId="C001", Price=120, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,1,7),  CustomerId="C002", Price=250, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,1,9),  CustomerId="C003", Price=300, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,1,12), CustomerId="C001", Price=180, Status="Pending" },
            //    new Order { OrderDate = new DateTime(2024,1,20), CustomerId="C004", Price=95,  Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,2,2),  CustomerId="C002", Price=400, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,2,3),  CustomerId="C005", Price=220, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,2,8),  CustomerId="C006", Price=175, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,2,15), CustomerId="C001", Price=330, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,2,25), CustomerId="C003", Price=280, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,3,1),  CustomerId="C004", Price=510, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,3,4),  CustomerId="C002", Price=190, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,3,7),  CustomerId="C006", Price=135, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,3,12), CustomerId="C005", Price=210, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,3,22), CustomerId="C001", Price=440, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,4,2),  CustomerId="C003", Price=150, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,4,6),  CustomerId="C004", Price=320, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,4,10), CustomerId="C002", Price=270, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,4,18), CustomerId="C005", Price=190, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,4,29), CustomerId="C006", Price=350, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,5,3),  CustomerId="C001", Price=275, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,5,5),  CustomerId="C003", Price=410, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,5,9),  CustomerId="C004", Price=360, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,5,15), CustomerId="C002", Price=280, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,5,21), CustomerId="C005", Price=145, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,6,2),  CustomerId="C006", Price=200, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,6,6),  CustomerId="C001", Price=340, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,6,12), CustomerId="C003", Price=190, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,6,18), CustomerId="C002", Price=400, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,6,28), CustomerId="C004", Price=260, Status="Cancelled" },

            //    new Order { OrderDate = new DateTime(2024,7,2),  CustomerId="C005", Price=310, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,7,5),  CustomerId="C006", Price=155, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,7,9),  CustomerId="C001", Price=220, Status="Pending" },
            //    new Order { OrderDate = new DateTime(2024,7,17), CustomerId="C002", Price=365, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,7,29), CustomerId="C004", Price=450, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,8,4),  CustomerId="C003", Price=280, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,8,8),  CustomerId="C005", Price=205, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,8,12), CustomerId="C006", Price=150, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,8,21), CustomerId="C001", Price=375, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,8,27), CustomerId="C002", Price=295, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,9,3),  CustomerId="C004", Price=420, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,9,9),  CustomerId="C005", Price=190, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,9,14), CustomerId="C006", Price=240, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,9,19), CustomerId="C003", Price=310, Status="Shipped" },
            //    new Order { OrderDate = new DateTime(2024,9,27), CustomerId="C001", Price=275, Status="Delivered" },

            //    new Order { OrderDate = new DateTime(2024,10,2), CustomerId="C002", Price=360, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,10,6), CustomerId="C003", Price=400, Status="Cancelled" },
            //    new Order { OrderDate = new DateTime(2024,10,12),CustomerId="C004", Price=280, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,10,20),CustomerId="C005", Price=215, Status="Delivered" },
            //    new Order { OrderDate = new DateTime(2024,10,28),CustomerId="C006", Price=330, Status="Delivered" }
            //};

            //var topCustomer = orders.GroupBy(x => x.CustomerId).OrderByDescending(x => x.Count()).FirstOrDefault();
            //foreach (Order o in topCustomer)
            //{
            //    Console.WriteLine($"OrderDate: {o.OrderDate}, CustomerId: {o.CustomerId}, Price: {o.Price}, Status: {o.Status}");
            //}

            //var monthlyRevenue = orders.Where(x => x.Status != "Cancelled")
            //    .GroupBy(x => x.OrderDate.Month)
            //    .Select(x => new
            //    {
            //        month = x.Key,
            //        revenue = x.Select(p => p.Price).Sum()

            //    });

            //foreach (var o in monthlyRevenue)
            //{
            //    Console.WriteLine($"{o.month} - {o.revenue}");
            //}

            //int totalOrders = orders.Count;
            //int cancelledOrders = orders.Count(o => o.Status == "Cancelled");
            //double cancelledPercentage = (double)cancelledOrders / totalOrders * 100;

            //Console.WriteLine(cancelledPercentage + "%");





            //დავალება 3
            //List<Employee> employees = new List<Employee>
            // {
            //     new Employee{ Id=1,  Name="Ana",    Department="IT",       Salary=3500, HireDate=new DateTime(2023,5,1)},
            //     new Employee{ Id=2,  Name="Giorgi", Department="Finance",  Salary=2800, HireDate=new DateTime(2022,3,12)},
            //     new Employee{ Id=3,  Name="Nino",   Department="HR",       Salary=3100, HireDate=new DateTime(2021,7,15)},
            //     new Employee{ Id=4,  Name="Luka",   Department="IT",       Salary=4000, HireDate=new DateTime(2024,2,10)},
            //     new Employee{ Id=5,  Name="Mariam", Department="Marketing",Salary=2500, HireDate=new DateTime(2020,1,25)},
            //     new Employee{ Id=6,  Name="Dato",   Department="Sales",    Salary=3300, HireDate=new DateTime(2023,11,5)},
            //     new Employee{ Id=7,  Name="Sopo",   Department="Finance",  Salary=2900, HireDate=new DateTime(2019,9,1)},
            //     new Employee{ Id=8,  Name="Irakli", Department="IT",       Salary=5000, HireDate=new DateTime(2024,7,8)},
            //     new Employee{ Id=9,  Name="Tiko",   Department="Sales",    Salary=2700, HireDate=new DateTime(2022,12,10)},
            //     new Employee{ Id=10, Name="Levan",  Department="HR",       Salary=3200, HireDate=new DateTime(2023,4,20)},
            //     new Employee{ Id=11, Name="Keti",   Department="Marketing",Salary=2950, HireDate=new DateTime(2021,5,30)},
            //     new Employee{ Id=12, Name="Nika",   Department="Finance",  Salary=4100, HireDate=new DateTime(2024,3,1)},
            //     new Employee{ Id=13, Name="Gvanca", Department="Sales",    Salary=3600, HireDate=new DateTime(2023,8,15)},
            //     new Employee{ Id=14, Name="Lizi",   Department="IT",       Salary=2800, HireDate=new DateTime(2020,10,18)},
            //     new Employee{ Id=15, Name="Zurab",  Department="HR",       Salary=4500, HireDate=new DateTime(2024,4,12)},
            //     new Employee{ Id=16, Name="Nana",   Department="Marketing",Salary=3100, HireDate=new DateTime(2022,9,25)},
            //     new Employee{ Id=17, Name="Vano",   Department="Finance",  Salary=2600, HireDate=new DateTime(2023,6,17)},
            //     new Employee{ Id=18, Name="Misha",  Department="Sales",    Salary=3400, HireDate=new DateTime(2021,2,28)},
            //     new Employee{ Id=19, Name="Salome", Department="IT",       Salary=3900, HireDate=new DateTime(2022,8,2)},
            //     new Employee{ Id=20, Name="Eka",    Department="HR",       Salary=2700, HireDate=new DateTime(2018,12,11)},
            // };

            //foreach (var e in employees)
            //{
            //    if (e.Salary > 3000)
            //        Console.WriteLine($"{e.Name}, {e.Department}, {e.Salary}");
            //}

            //List<Employee> highSalary = new List<Employee>(employees);


            //highSalary.Sort((a, b) =>
            //{
            //    int depCompare = a.Department.CompareTo(b.Department);
            //    if (depCompare != 0) return depCompare;
            //    return a.Salary.CompareTo(b.Salary);
            //});

            //foreach (var emp in highSalary)
            //{
            //    Console.WriteLine($"{emp.Id}. {emp.Name} - {emp.Department} - {emp.Salary}");
            //}

            //var avgSalary = employees
            //.GroupBy(e => e.Department)
            //.Select(x => new
            //{
            //    departament = x.Key,
            //    salary = x.Select(s => s.Salary).Average()
            //});

            //foreach(var a in avgSalary)
            //{
            //    Console.WriteLine($"{a.departament} - {a.salary}");
            //}

            //var newest = employees.OrderByDescending(e => e.HireDate).Take(5);
            //foreach (var e in newest)
            //{
            //    Console.WriteLine($"{e.Name}, {e.Department}, {e.HireDate.ToShortDateString()}");
            //}

           // var topInDept = employees
           //.GroupBy(e => e.Department)
           //.Select(x => new
           //{
           //    departament = x.Key,
           //    topSalary = x.Select(x=> x.Salary).Max()
           //});

           // foreach(var t in topInDept)
           // {
           //     Console.WriteLine($"{t.departament} - {t.topSalary}");
           // }    
        }

        public class Student
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public int Age { get; set; }
            public int Grade { get; set; }
        }

        public class Order
        {
            public DateTime OrderDate { get; set; }
            public string CustomerId { get; set; }
            public decimal Price { get; set; }
            public string Status { get; set; } // "Pending", "Shipped", "Delivered", "Cancelled"
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public DateTime HireDate { get; set; }
        }
    }
}
