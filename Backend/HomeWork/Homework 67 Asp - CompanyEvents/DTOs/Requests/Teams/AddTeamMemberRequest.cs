namespace Homework_67_Asp___CompanyEvents.DTOs.Requests.Teams
{
    public record AddTeamMemberRequest(
        int TeamId,
        int UserId
    );
}
