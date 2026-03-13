using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class FacultyDean
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime AppointedDate { get; set; }
        public string Email { get; set; }
        public string OfficeRoom { get; set; }

        // Foreign Key → Faculty
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
