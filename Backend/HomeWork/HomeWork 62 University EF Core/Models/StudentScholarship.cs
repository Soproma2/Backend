using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class StudentScholarship
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ScholarshipId { get; set; }
        public Scholarship Scholarship { get; set; }

        public DateTime AwardedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
