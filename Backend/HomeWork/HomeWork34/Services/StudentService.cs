using HomeWork34.Data;
using HomeWork34.Models;
using Microsoft.EntityFrameworkCore;
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
            Console.Write("Enter Firstname: ");
            string FName = Console.ReadLine();

            Console.Write("Enter Lastname: ");
            string Lname = Console.ReadLine();

            Console.Write("Enter Student E-Mail: ");
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

            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Phonenumber: ");
            string phonenumber = Console.ReadLine();

            Console.Write("Enter Student Country: ");
            string country = Console.ReadLine();

            var student = _db.students.FirstOrDefault(s => s.Email == email);
           
            if (student == null)
            {
                Console.WriteLine("Student not found!");
            }

            StudentDetail studentDetail = new StudentDetail()
            {
                Age = age,
                PhoneNumber = phonenumber,
                Country = country,
                StudentId = student.Id
            };

            _db.studentDetails.Add(studentDetail);
            _db.SaveChanges();
            Console.WriteLine("Student Detail Added successfully.");
        }

        public void ShowStudent()
        {
            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();

            var student = _db.students
                .Include(d=>d.studentDetail)
                .FirstOrDefault(s => s.Email == email);

            if(student == null)
            {
                Console.WriteLine("Student not found!");
            }

            if (student.studentDetail == null)
            {
                Console.WriteLine($"Name: {student.Name} | Email: {student.Email}");
                Console.WriteLine("This student has no details added yet!");
                return;
            }

            Console.WriteLine($"\nName: {student.Name}  \nEmail: {student.Email}  \nAge: {student.studentDetail.Age}  \nPhoneNumber: {student.studentDetail.PhoneNumber}  \nCountry: {student.studentDetail.Country}");
        }

        public void ShowStudents()
        {
            var students = _db.students.ToList();
            if(students.Count == 0 || students == null)
            {
                Console.WriteLine("Students not found!");
            }
            foreach ( var student in students )
            {
                Console.WriteLine($"Name: {student.Name} | Email: {student.Email}");
            }
        }
    }
}
