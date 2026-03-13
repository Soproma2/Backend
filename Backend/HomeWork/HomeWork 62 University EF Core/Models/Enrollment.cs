using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrolledAt { get; set; }
        public double? Grade { get; set; }
        public Status Status { get; set; }
    }
}
