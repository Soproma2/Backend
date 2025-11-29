using HomeWork38.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Models
{
    internal class Product : BaseEntity
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime ExpiersAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
