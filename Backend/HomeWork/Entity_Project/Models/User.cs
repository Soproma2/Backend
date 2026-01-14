using Entity_Project.Core;
using Entity_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Models
{
    internal class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public double Balance { get; set; }
        public string? VerificationCode { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;

        public Profile? Profile { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
