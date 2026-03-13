using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Scholarship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Donor { get; set; }
        public string Requirements { get; set; }

        // MANY-TO-MANY ნავიგაცია
        public ICollection<StudentScholarship> StudentScholarships { get; set; } = new List<StudentScholarship>();
    }
}
