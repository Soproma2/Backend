using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.Data;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Teams;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Teams;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_67_Asp___CompanyEvents.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _db;

        public TeamService(AppDbContext db)
        {
            _db = db;
        }
        public Result<TeamResponse> CreateTeam(int captainUserId, CreateTeamRequest request)
        {
            var activity = _db.Activities.Find(request.ActivityId);
            if (activity is null)
                return Result.Failure<TeamResponse>("ღონისძიება ვერ მოიძებნა.");

            if (activity.Type != ActivityType.Competition || activity.CompetitionType != CompetitionType.Team)
                return Result.Failure<TeamResponse>("გუნდების შექმნა მხოლოდ გუნდურ შეჯიბრებებშია შესაძლებელი.");

            if (_db.Teams.Any(t => t.ActivityId == request.ActivityId && t.Name == request.Name))
                return Result.Failure<TeamResponse>("ამ სახელით გუნდი უკვე არსებობს.");

            var team = new Team
            {
                Name = request.Name,
                ActivityId = request.ActivityId,
                CaptainUserId = captainUserId
            };

            _db.Teams.Add(team);
            _db.SaveChanges();

            _db.TeamMembers.Add(new TeamMember { TeamId = team.Id, UserId = captainUserId });
            _db.SaveChanges();

            return GetById(team.Id);
        }

        public Result<TeamResponse> GetById(int teamId)
        {
            var t = _db.Teams
                .Include(t => t.Captain)
                .Include(t => t.Activity)
                .Include(t => t.Members).ThenInclude(m => m.User)
                .FirstOrDefault(t => t.Id == teamId);

            if (t is null)
                return Result.Failure<TeamResponse>("გუნდი ვერ მოიძებნა.");

            return Result.Success(new TeamResponse(
                t.Id, t.Name, t.ActivityId, t.Activity.Title,
                t.Captain.FullName, t.Members.Count,
                t.Members.Select(m => new TeamMemberResponse(m.UserId, m.User.FullName, m.JoinedAt)).ToList()
            ));
        }

        public Result<List<TeamResponse>> GetByActivity(int activityId)
        {
            var list = _db.Teams
                .Include(t => t.Captain)
                .Include(t => t.Activity)
                .Include(t => t.Members).ThenInclude(m => m.User)
                .Where(t => t.ActivityId == activityId)
                .Select(t => new TeamResponse(
                    t.Id, t.Name, t.ActivityId, t.Activity.Title,
                    t.Captain.FullName, t.Members.Count,
                    t.Members.Select(m => new TeamMemberResponse(m.UserId, m.User.FullName, m.JoinedAt)).ToList()
                ))
                .ToList();

            return Result.Success(list);
        }

        public Result AddMember(int requestingUserId, AddTeamMemberRequest request)
        {
            var team = _db.Teams
                .Include(t => t.Members)
                .Include(t => t.Activity)
                .FirstOrDefault(t => t.Id == request.TeamId);

            if (team is null)
                return Result.Failure("გუნდი ვერ მოიძებნა.");

            if (team.CaptainUserId != requestingUserId)
                return Result.Failure("მხოლოდ კაპიტანს შეუძლია წევრების დამატება.");

            if (team.Members.Any(m => m.UserId == request.UserId))
                return Result.Failure("მომხმარებელი უკვე გუნდის წევრია.");

            if (team.Activity.MaxTeamSize.HasValue && team.Members.Count >= team.Activity.MaxTeamSize.Value)
                return Result.Failure("გუნდი მაქსიმალური ზომისაა.");

            _db.TeamMembers.Add(new TeamMember { TeamId = request.TeamId, UserId = request.UserId });
            _db.SaveChanges();
            return Result.Success();
        }

        public Result RemoveMember(int requestingUserId, int teamId, int userId)
        {
            var team = _db.Teams.Find(teamId);
            if (team is null)
                return Result.Failure("გუნდი ვერ მოიძებნა.");

            if (team.CaptainUserId != requestingUserId && requestingUserId != userId)
                return Result.Failure("წვდომა აკრძალულია.");

            if (team.CaptainUserId == userId)
                return Result.Failure("კაპიტანი ვერ წაიშლება გუნდიდან.");

            var member = _db.TeamMembers.FirstOrDefault(m => m.TeamId == teamId && m.UserId == userId);
            if (member is null)
                return Result.Failure("წევრი ვერ მოიძებნა.");

            _db.TeamMembers.Remove(member);
            _db.SaveChanges();
            return Result.Success();
        }

        public Result DeleteTeam(int requestingUserId, int teamId)
        {
            var team = _db.Teams.Find(teamId);
            if (team is null)
                return Result.Failure("გუნდი ვერ მოიძებნა.");

            if (team.CaptainUserId != requestingUserId)
                return Result.Failure("მხოლოდ კაპიტანს შეუძლია გუნდის წაშლა.");

            _db.Teams.Remove(team);
            _db.SaveChanges();
            return Result.Success();
        }
    }
}
