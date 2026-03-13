using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class CourseTeacher
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Role Role { get; set; }
        public DateTime AssignedFrom { get; set; }
    }
}
