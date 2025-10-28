using E_Commerce_Shopping_Cart_System.Core;
using E_Commerce_Shopping_Cart_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Models
{
    internal class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public double Balance { get; set; } = 1000;
        public bool IsActive { get; set; } = true;

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<Order> Orders{ get; set; } = new List<Order>();
    }
}
