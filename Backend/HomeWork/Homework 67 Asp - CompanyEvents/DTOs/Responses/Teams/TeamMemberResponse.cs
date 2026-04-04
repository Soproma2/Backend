namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Teams
{
    public record TeamMemberResponse(
        int UserId,
        string FullName,
        DateTime JoinedAt
    );
}
