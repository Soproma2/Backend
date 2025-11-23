using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne4.Models
{
    internal class EmployeeSalaryInfo
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }
        
        public int EmployeeId { get; set; }
    }
}
