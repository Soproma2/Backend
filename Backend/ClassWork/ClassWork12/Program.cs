using System.Text;

namespace ClassWork12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{ Id=1,  Name="Ana",    Department="IT",       Salary=3500, HireDate=new DateTime(2023,5,1)},
                new Employee{ Id=2,  Name="Giorgi", Department="Finance",  Salary=2800, HireDate=new DateTime(2022,3,12)},
                new Employee{ Id=3,  Name="Nino",   Department="HR",       Salary=3100, HireDate=new DateTime(2021,7,15)},
                new Employee{ Id=4,  Name="Luka",   Department="IT",       Salary=4000, HireDate=new DateTime(2024,2,10)},
                new Employee{ Id=5,  Name="Mariam", Department="Marketing",Salary=2500, HireDate=new DateTime(2020,1,25)},
                new Employee{ Id=6,  Name="Dato",   Department="Sales",    Salary=3300, HireDate=new DateTime(2023,11,5)},
                new Employee{ Id=7,  Name="Sopo",   Department="Finance",  Salary=2900, HireDate=new DateTime(2019,9,1)},
                new Employee{ Id=8,  Name="Irakli", Department="IT",       Salary=5000, HireDate=new DateTime(2024,7,8)},
                new Employee{ Id=9,  Name="Tiko",   Department="Sales",    Salary=2700, HireDate=new DateTime(2022,12,10)},
                new Employee{ Id=10, Name="Levan",  Department="HR",       Salary=3200, HireDate=new DateTime(2023,4,20)}
            };

            int page = 2;
            int pageSize = 5;
            int skip = 5;

            var pagination = employees.Skip(skip * page).Take(pageSize+1).ToList();
            var hasmore = pagination.Count > pageSize;
            var response = hasmore ? pagination.Slice(0, pageSize) : pagination;

            Console.WriteLine(hasmore);
            foreach(var p in response)
            {
                Console.WriteLine($"{p.Id} - {p.Name} - {p.Department} - {p.Salary} - {p.HireDate}");
            }

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
