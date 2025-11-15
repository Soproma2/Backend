using HomeWork31.Data;
using HomeWork31.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31.Services
{
    internal class StudentService
    {
        DataContext _db = new DataContext();

        public void CreateStudent()
        {
            Console.WriteLine("Enter Firstname: ");
            string fname = Console.ReadLine();

            Console.WriteLine("Enter Lastname: ");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Student student = new Student()
            {
                Name = $"{fname} {lname}",
                Age = age
            };

            _db.Students.Add(student);
            _db.SaveChanges();
            Console.WriteLine("Student Added Successfully.");
        }

        public void ShowStudents()
        {
            var students = _db.Students.ToList();

            if(students.Count == 0)
            {
                Console.WriteLine("Students not found!");
                return;
            }

            foreach(var student in students)
            {
                Console.WriteLine($"Id: {student.Id} - Name: {student.Name} - Age: {student.Age}");
            }
        }

        public void ShowStudentById()
        {
            Console.WriteLine("Enter student Id: ");
            int Id = int.Parse(Console.ReadLine());

            var student = _db.Students
                .Include(c=>c.Courses)
                .FirstOrDefault(x => x.Id == Id);

            if(student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.WriteLine($"Name: {student.Name} - Age: {student.Age}");
            Console.WriteLine("Courses:");
            if (student.Courses.Count == 0)
            {
                Console.WriteLine("Courses not found!");
                return;
            }

            foreach (var c in student.Courses)
            {
                Console.WriteLine($"Course Name: {c.Title}");
            }
        }

    }
}
