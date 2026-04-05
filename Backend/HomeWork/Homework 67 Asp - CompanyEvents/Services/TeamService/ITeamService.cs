using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Teams;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Teams;

namespace Homework_67_Asp___CompanyEvents.Services.TeamService
{
    public interface ITeamService
    {
        Result<TeamResponse> CreateTeam(int captainUserId, CreateTeamRequest request);
        Result<TeamResponse> GetById(int teamId);
        Result<List<TeamResponse>> GetByActivity(int activityId);
        Result AddMember(int requestingUserId, AddTeamMemberRequest request);
        Result RemoveMember(int requestingUserId, int teamId, int userId);
        Result DeleteTeam(int requestingUserId, int teamId);
    }
}
