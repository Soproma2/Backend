using E_Commerce_Shopping_Cart_System.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Models
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
