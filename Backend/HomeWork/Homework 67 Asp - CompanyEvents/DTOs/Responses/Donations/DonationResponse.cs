namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Donations
{
    public record DonationResponse(
    int Id,
    int UserId,
    string UserFullName,
    decimal Amount,
    string DonationType,
    string Status,
    string? Purpose,
    int? ActivityId,
    string? ActivityTitle,
    DateTime CreatedAt,
    DateTime? NextBillingDate
    );
}
