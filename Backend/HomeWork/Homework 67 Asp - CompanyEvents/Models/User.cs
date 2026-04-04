using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public List<Registration> Registrations { get; set; } = new();
        public List<TeamMember> TeamMemberships { get; set; } = new();
        public List<Donation> Donations { get; set; } = new();
    }
}
