namespace Homework_67_Asp___CompanyEvents.DTOs.Responses.Teams
{
    public record TeamResponse(
        int Id,
        string Name,
        int ActivityId,
        string ActivityTitle,
        string CaptainName,
        int MemberCount,
        List<TeamMemberResponse> Members
    );
}
