using Homework_67_Asp___CompanyEvents.Enums;

namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Activities
{
    public record CreateActivityRequest(
        string Title,
        string Description,
        string Location,
        DateTime StartDate,
        DateTime EndDate,
        ActivityType Type,
        string? ImageUrl,
        int MaxParticipants,
        int MaxSpectators,

        CompetitionType? CompetitionType,
        int? MaxTeamSize,
        int? MinTeamSize
    );
}
