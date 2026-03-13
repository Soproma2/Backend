using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class ProfessorProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }

        // Foreign Key → Professor
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
