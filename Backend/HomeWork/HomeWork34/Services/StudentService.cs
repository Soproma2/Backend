using HomeWork34.Data;
using HomeWork34.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork34.Services
{
    internal class StudentService
    {
        DataContext _db = new DataContext();
        public void AddStudent()
        {
            Console.WriteLine("Enter Firstname: ");
            string FName = Console.ReadLine();

            Console.WriteLine("Enter Lastanem: ");
            string Lname = Console.ReadLine();

            Console.WriteLine("Enter SStudent E-Mail: ");
            string email = Console.ReadLine();

            Student student = new Student()
            {
                Name = $"{FName} {Lname}",
                Email = email
            };

            _db.students.Add(student);
            _db.SaveChanges();
            Console.WriteLine("Student Added successfully.");
        }

        public void AddStudentDetails()
        {

            Console.WriteLine("Enter Student Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Phonenumber: ");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Enter Student Country: ");
            string country = Console.ReadLine();
        }
    }
}
