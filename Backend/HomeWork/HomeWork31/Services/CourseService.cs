using HomeWork31.Data;
using HomeWork31.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HomeWork31.Services
{
    internal class CourseService
    {
        DataContext _db = new DataContext();
        public void addCourse()
        {
            Console.WriteLine("Enter Course Title: ");
            string title = Console.ReadLine();

            Course course = new Course()
            {
                Title = title
            };

            _db.Courses.Add(course);
            _db.SaveChanges();
            Console.WriteLine("Course added successfully.");
        }

        public void courses()
        {
            var courses = _db.Courses.ToList();

            if(courses.Count == 0 || courses == null)
            {
                Console.WriteLine("Courses not found!");
                return;
            }

            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id}. {course.Title}");
            }
        }

        public void addCourseStudent()
        {
            Console.WriteLine("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Course Id: ");
            int courseId = int.Parse(Console.ReadLine());

            var student = _db.Students.FirstOrDefault(s=>s.Id == studentId);
            if(student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            var course = _db.Courses.FirstOrDefault(s=>s.Id == courseId);
            if(course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            student.Courses.Add(course);
            _db.SaveChanges();
            Console.WriteLine("Student successfully added a course");
        }
    }
}
