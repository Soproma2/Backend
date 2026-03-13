using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Email { get; set; }
        public int EnrollmentYear { get; set; }

        // ONE-TO-ONE
        public StudentProfile StudentProfile { get; set; }

        // MANY-TO-MANY ნავიგაციები
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<StudentClub> StudentClubs { get; set; } = new List<StudentClub>();
        public ICollection<StudentScholarship> StudentScholarships { get; set; } = new List<StudentScholarship>();
    }
}
