using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Enums;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public List<Order> Orders { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public Cart? Cart { get; set; }
    }
}
