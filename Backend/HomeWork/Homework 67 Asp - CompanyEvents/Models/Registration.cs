using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public int? TeamId { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;


        public User User { get; set; } = null!;
        public Activity Activity { get; set; } = null!;
        public Team? Team { get; set; }
    }
}
