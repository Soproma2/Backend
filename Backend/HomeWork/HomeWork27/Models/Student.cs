using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork27.Models
{
    internal class Student
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public string Course { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public double GPA { get; set; }

        public bool IsActive { get; set; } = true;


        public override string ToString()
        {
            return $"{StudentNumber} - {FirstName} {LastName} - Age: {Age} - Course: ({Course}) - GPA: {GPA} - Enrollment date: {EnrollmentDate}";
        }
    }
}
