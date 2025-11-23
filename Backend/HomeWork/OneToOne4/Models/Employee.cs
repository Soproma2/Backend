using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne4.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
    }
}
