using HomeWork27.Data;
using HomeWork27.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork27.Services
{
    public class StudentService
    {
        DataContext _db = new DataContext();
        public void AddStudent()
        {
            Console.Write("Enter student Firstname: ");
            string SFirstname = Console.ReadLine();

            Console.Write("Enter student Lastname: ");
            string SLastname = Console.ReadLine();

            Console.Write("Enter student Age: ");
            int SAge = int.Parse(Console.ReadLine());

            Console.Write("Eneter student E-mail: ");
            string SEmail = Console.ReadLine();

            Console.Write("Enter student Course: ");
            string SCourse = Console.ReadLine();

            Console.Write("Enter student GPA: ");
            double SGPA = double.Parse(Console.ReadLine());

            Student student = new Student()
            {
                FirstName = SFirstname,
                LastName = SLastname,
                Age = SAge,
                Email = SEmail,
                Course = SCourse,
                GPA = SGPA
            };

            _db.students.Add(student);
            _db.SaveChanges();
            Console.WriteLine("Student Added Successfully.");
        }

        public void GetStudentById()
        {
            Console.Write("Enter student ID: ");
            int SID = int.Parse(Console.ReadLine());

            var student = _db.students.Find(SID);

            if (student == null) throw new Exception("Student not found!");

            Console.WriteLine(student);
        }

        public void GetAllStudents()
        {
            var students = _db.students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void UpdateStudent()
        {
            GetAllStudents();

            Console.Write("Enter student ID: ");
            int SID = int.Parse(Console.ReadLine());

            var student = _db.students.Find(SID);

            if (student == null) throw new Exception("Student not found!");

            Console.Write("Selected student: ");
            Console.WriteLine(student);
            Console.WriteLine("");

            Console.Write("Enter student new Firstname: ");
            string SFirstname = Console.ReadLine();

            Console.Write("Enter student new Lastname: ");
            string SLastname = Console.ReadLine();

            Console.Write("Enter student new Age: ");
            int SAge = int.Parse(Console.ReadLine());

            Console.Write("Enter student new Course: ");
            string SCourse = Console.ReadLine();

            Console.Write("Enter student new GPA: ");
            double SGPA = double.Parse(Console.ReadLine());

            student.FirstName = SFirstname;
            student.LastName = SLastname;
            student.Age = SAge;
            student.Course = SCourse;
            student.GPA = SGPA;

            _db.SaveChanges();
            Console.WriteLine("Student updated succesfully.");
        }

        public void DeleteStudent()
        {
            GetAllStudents();

            Console.Write("Enter student ID: ");
            int SID = int.Parse(Console.ReadLine());

            var student = _db.students.Find(SID);

            if (student == null) throw new Exception("Student not found!");

            _db.students.Remove(student);
            _db.SaveChanges();
            Console.WriteLine("Student deleted succesfuly.");
        }

        public void SearchStudents()
        {
            Console.WriteLine("-----Search student-----");
            Console.Write("Enter student firstname: ");
            string SFirstname = Console.ReadLine();
            Console.Write("Enter student lastname: ");
            string SLastname = Console.ReadLine();

            var students = _db.students
                .Where(s => s.FirstName.ToLower().Contains(SFirstname.ToLower()) ||
                s.LastName.ToLower().Contains(SLastname.ToLower())).ToList();
            
            foreach(var student in students)
            {
                Console.WriteLine(student);
            }


        }

        public void DeactivateStudent()
        {
            Console.Write("Enter student ID: ");
            int SID = int.Parse(Console.ReadLine());

            var student = _db.students.Find(SID);

            if (student == null) throw new Exception("Student not found!");
            if (!student.IsActive) throw new Exception("Stuent already deactivated!");

            student.IsActive = false;

            _db.SaveChanges();
            Console.WriteLine("Student deactivated!");
        }

        public void ActivateStudent()
        {
            Console.Write("Enter student ID: ");
            int SID = int.Parse(Console.ReadLine());

            var student = _db.students.Find(SID);

            if (student == null) throw new Exception("Student not found!");
            if (student.IsActive) throw new Exception("Stuent already activated!");

            student.IsActive = true;

            _db.SaveChanges();
            Console.WriteLine("Student activated!");
        }

        public void GetTopStudents()
        {
            var student = _db.students.OrderByDescending(e => e.GPA).FirstOrDefault();
            if(student == null) throw new Exception("Students not found!");
            Console.WriteLine(student);
        }
    }
}
