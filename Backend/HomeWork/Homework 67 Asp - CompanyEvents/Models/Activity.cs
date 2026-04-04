using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityType Type { get; set; }
        public string? ImageUrl { get; set; }
        public int MaxParticipants { get; set; }
        public int MaxSpectators { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public CompetitionType? CompetitionType { get; set; }
        public int? MaxTeamSize { get; set; }
        public int? MinTeamSize { get; set; }

        
        public List<Registration> Registrations { get; set; } = [];
        public List<Team> Teams { get; set; } = [];
    }
}
