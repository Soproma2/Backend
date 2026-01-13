using Entity_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Models
{
    internal class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
