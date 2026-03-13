using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        // MANY-TO-MANY ნავიგაციები
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
        public ICollection<CourseTextbook> CourseTextbooks { get; set; } = new List<CourseTextbook>();
    }
}
