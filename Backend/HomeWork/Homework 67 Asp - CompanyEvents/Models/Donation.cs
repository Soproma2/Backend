using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DonationType DonationType { get; set; }
        public DonationStatus Status { get; set; } = DonationStatus.Active;
        public string? Purpose { get; set; }
        public int? ActivityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? NextBillingDate { get; set; }
        public DateTime? CancelledAt { get; set; }


        public User User { get; set; } = null!;
        public Activity? Activity { get; set; }
    }
}
