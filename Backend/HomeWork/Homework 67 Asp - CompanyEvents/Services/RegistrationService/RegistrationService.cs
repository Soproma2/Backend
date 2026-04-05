using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.Data;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Registrations;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Registrations;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_67_Asp___CompanyEvents.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _db;

        public RegistrationService(AppDbContext db)
        {
            _db = db;
        }
        public Result<RegistrationResponse> Register(int userId, RegisterToActivityRequest request)
        {
            var activity = _db.Activities
                .Include(a => a.Registrations)
                .FirstOrDefault(a => a.Id == request.ActivityId);

            if (activity is null)
                return Result.Failure<RegistrationResponse>("ღონისძიება ვერ მოიძებნა.");

            if (!activity.IsActive)
                return Result.Failure<RegistrationResponse>("ღონისძიება არააქტიურია.");

            if (activity.Type == ActivityType.Event && request.RegistrationType == RegistrationType.Participant)
                return Result.Failure<RegistrationResponse>("Event-ზე მხოლოდ მაყურებლად რეგისტრაციაა შესაძლებელი.");

            if (_db.Registrations.Any(r => r.UserId == userId && r.ActivityId == request.ActivityId))
                return Result.Failure<RegistrationResponse>("თქვენ უკვე დარეგისტრირებული ხართ.");

            if (request.RegistrationType == RegistrationType.Participant &&
                activity.Registrations.Count(r => r.RegistrationType == RegistrationType.Participant) >= activity.MaxParticipants)
                return Result.Failure<RegistrationResponse>("მონაწილეთა ლიმიტი ამოიწურა.");

            if (request.RegistrationType == RegistrationType.Spectator &&
                activity.Registrations.Count(r => r.RegistrationType == RegistrationType.Spectator) >= activity.MaxSpectators)
                return Result.Failure<RegistrationResponse>("მაყურებელთა ლიმიტი ამოიწურა.");

            if (request.TeamId.HasValue)
            {
                var team = _db.Teams.Find(request.TeamId.Value);
                if (team is null || team.ActivityId != request.ActivityId)
                    return Result.Failure<RegistrationResponse>("გუნდი ვერ მოიძებნა.");
            }

            var reg = new Registration
            {
                UserId = userId,
                ActivityId = request.ActivityId,
                RegistrationType = request.RegistrationType,
                TeamId = request.TeamId
            };

            _db.Registrations.Add(reg);
            _db.SaveChanges();

            var result = _db.Registrations
                .Include(r => r.User)
                .Include(r => r.Activity)
                .Include(r => r.Team)
                .Select(r => new RegistrationResponse(
                    r.Id, r.UserId, r.User.FullName,
                    r.ActivityId, r.Activity.Title,
                    r.RegistrationType.ToString(),
                    r.Team != null ? r.Team.Name : null,
                    r.RegisteredAt
                ))
                .First(r => r.Id == reg.Id);

            return Result.Success(result);
        }

        public Result Unregister(int userId, int activityId)
        {
            var reg = _db.Registrations.FirstOrDefault(r => r.UserId == userId && r.ActivityId == activityId);
            if (reg is null)
                return Result.Failure("რეგისტრაცია ვერ მოიძებნა.");

            _db.Registrations.Remove(reg);
            _db.SaveChanges();
            return Result.Success();
        }

        public Result<List<RegistrationResponse>> GetByActivity(int activityId)
        {
            var list = _db.Registrations
                .Include(r => r.User)
                .Include(r => r.Activity)
                .Include(r => r.Team)
                .Where(r => r.ActivityId == activityId)
                .Select(r => new RegistrationResponse(
                    r.Id, r.UserId, r.User.FullName,
                    r.ActivityId, r.Activity.Title,
                    r.RegistrationType.ToString(),
                    r.Team != null ? r.Team.Name : null,
                    r.RegisteredAt
                ))
                .ToList();

            return Result.Success(list);
        }

        public Result<List<RegistrationResponse>> GetByUser(int userId)
        {
            var list = _db.Registrations
                .Include(r => r.User)
                .Include(r => r.Activity)
                .Include(r => r.Team)
                .Where(r => r.UserId == userId)
                .Select(r => new RegistrationResponse(
                    r.Id, r.UserId, r.User.FullName,
                    r.ActivityId, r.Activity.Title,
                    r.RegistrationType.ToString(),
                    r.Team != null ? r.Team.Name : null,
                    r.RegisteredAt
                ))
                .ToList();

            return Result.Success(list);
        }
    }
}
