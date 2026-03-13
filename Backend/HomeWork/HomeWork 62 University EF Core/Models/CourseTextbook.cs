using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class CourseTextbook
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TextbookId { get; set; }
        public Textbook Textbook { get; set; }

        public bool IsMandatory { get; set; }
    }
}
