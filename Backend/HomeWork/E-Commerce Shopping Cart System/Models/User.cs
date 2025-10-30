using E_Commerce_Shopping_Cart_System.Core;
using E_Commerce_Shopping_Cart_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public double Balance { get; set; }

        public List<CartItem> CartItems { get; set; }
        public List<Order> Orders{ get; set; }
    }
}
