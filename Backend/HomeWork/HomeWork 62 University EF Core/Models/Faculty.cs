using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public int EstablishedYear { get; set; }

        // ONE-TO-ONE
        public FacultyDean FacultyDean { get; set; }

        // ფაკულტეტს ეკუთვნის კურსები
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
