using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.Enums;

namespace HomeWork_57___Asp_E_Commerce.Models
{
    public class User : BaseEntity
    {
        public string Username  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public double Balance { get; set; }
        public string? VerificationCode { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;

        public Profile? profile { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
