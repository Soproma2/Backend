using HomeWork33.Data;
using HomeWork33.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork33.Services
{
    internal class SchoolService
    {
        DataContext _db = new DataContext();
        public void AddStudent()
        {
            Console.WriteLine("Enter Firstname: ");
            string Fname = Console.ReadLine();

            Console.WriteLine("Enter Lastname: ");
            string Lname = Console.ReadLine();

            Student student = new Student()
            {
                Name = $"{Fname} {Lname}"
            };

            _db.Students.Add(student);
            _db.SaveChanges();
            Console.WriteLine("Student Added Successfully.");
        }

        public void AddCourse()
        {
            Console.WriteLine("Enter Course Name: ");
            string CourseName = Console.ReadLine();

            Course course = new Course()
            {
                Title = CourseName
            };

            _db.Courses.Add(course);
            _db.SaveChanges();
            Console.WriteLine("Course Added Successfully.");
        }

        public void StudentCourse()
        {
            Console.WriteLine("Enter Student Id: ");
            int StudentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Course Id: ");
            int CourseId = int.Parse(Console.ReadLine());

            var student = _db.Students.Find(StudentId);
            if(student == null)
            {
                Console.WriteLine("Student not found!");
            }
            var course = _db.Courses.Find(CourseId);
            if(course == null)
            {
                Console.WriteLine("Course not found!");
            }

            course.Students.Add(student);
            Console.WriteLine($"Student Registered Succesfully! Course name: {course.Title}");
        }

    }
}
