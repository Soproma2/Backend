using HomeWork_60___ASP_Cars.Enums;

namespace HomeWork_60___ASP_Cars.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.Buyer;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
