using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne3.Models
{
    internal class ProductSpecification
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public string Material { get; set; }
        public DateTime WarrantyMonths { get; set; }

        public int ProductId { get; set; }
    }
}
