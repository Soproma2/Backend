using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Donations
{
    public record CreateDonationRequest(
        decimal Amount,
        DonationType DonationType,
        string? Purpose,
        int? ActivityId
    );
}
