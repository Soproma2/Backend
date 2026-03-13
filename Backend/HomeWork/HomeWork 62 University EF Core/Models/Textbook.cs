using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Textbook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }

        // MANY-TO-MANY ნავიგაცია
        public ICollection<CourseTextbook> CourseTextbooks { get; set; } = new List<CourseTextbook>();
    }
}
