using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork23.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name ,double price)
        {
            Name = name;
            Price = price;
        }
    }
}
