namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Activities
{
    public record UpdateActivityRequest(
    string? Title,
    string? Description,
    string? Location,
    DateTime? StartDate,
    DateTime? EndDate,
    string? ImageUrl,
    int? MaxParticipants,
    int? MaxSpectators,
    bool? IsActive
);
}
