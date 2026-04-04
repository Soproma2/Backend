namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Activities
{
    public record ActivityResponse(
        int Id,
        string Title,
        string Description,
        string Location,
        DateTime StartDate,
        DateTime EndDate,
        string Type,
        string? ImageUrl,
        int MaxParticipants,
        int MaxSpectators,
        int CurrentParticipants,
        int CurrentSpectators,
        bool IsActive,

        string? CompetitionType,
        int? MaxTeamSize,
        int? MinTeamSize
    );
}
