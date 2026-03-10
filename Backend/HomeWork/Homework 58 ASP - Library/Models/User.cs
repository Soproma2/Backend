using Homework_58_ASP___Library.Enums;

namespace Homework_58_ASP___Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public DateTime RegisteredAt { get; set; } = DateTime.Now;

    }
}
