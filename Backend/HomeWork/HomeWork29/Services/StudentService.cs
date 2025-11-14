using HomeWork29.Data;
using HomeWork29.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HomeWork29.Services
{
    internal class StudentService
    {
        DataContext _db = new DataContext();
        public void studenReg()
        {
            Console.WriteLine("Enter firstName: ");
            string fName = Console.ReadLine();

            Console.WriteLine("Enter LastName: ");
            string lName = Console.ReadLine();

            Console.WriteLine("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Student student = new Student()
            {
                Name = $"{fName} {lName}",
                Age = age,
                passport = new Passport() { FirstName = fName, LastName = lName, CreatedAt = DateTime.Now }
            };

            _db.students .Add(student);
            _db.SaveChanges();
            Console.WriteLine("Student registered successfully.");
        }

        public void ShowStudents()
        {
            Console.WriteLine("Enter student Id: ");
            int Id = int.Parse(Console.ReadLine());

            var stud = _db.students.Include(p=>p.passport).FirstOrDefault(s=>s.Id == Id);

            if(stud == null)
            {
                Console.WriteLine("Student not found!");
            }

            Console.WriteLine($"Name: {stud.Name}, Age: {stud.Age}, PassFName: {stud.passport.FirstName}, PassLName: {stud.passport.LastName}, CreatedAt: {stud.passport.CreatedAt}");
        }
    }
}
