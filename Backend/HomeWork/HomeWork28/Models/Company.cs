using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28.Models
{
    internal class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }
    }
}
