using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne5.Models
{
    internal class CarServiceBook
    {
        public int Id { get; set; }
        public DateTime LastServiceDate { get; set; }
        public DateTime NextServiceDate { get; set; }
        public string ServiceNotes { get; set; }

        public int CarId { get; set; }
    }
}
