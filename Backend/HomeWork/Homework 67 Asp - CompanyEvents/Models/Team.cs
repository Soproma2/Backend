namespace Homework_67_Asp___CompanyEvents.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public int CaptainUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public Activity Activity { get; set; } = null!;
        public User Captain { get; set; } = null!;
        public List<TeamMember> Members { get; set; } = new();
        public List<Registration> Registrations { get; set; } = new();
    }
}
