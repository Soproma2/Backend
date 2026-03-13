using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Professor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public AcademicRank AcademicRank { get; set; }

        // ONE-TO-ONE
        public ProfessorProfile ProfessorProfile { get; set; }

        // MANY-TO-MANY ნავიგაციები
        public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
    }
}
