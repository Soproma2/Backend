using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne2.Models
{
    internal class StudentCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public int StudentId { get; set; }
    }
}
