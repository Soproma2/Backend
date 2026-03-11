using HomeWork_61_Asp___Restaurant.Enums;

namespace HomeWork_61_Asp___Restaurant.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
