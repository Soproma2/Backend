using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.Data;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Activities;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Activities;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_67_Asp___CompanyEvents.Services.ActivityService
{
    public class ActivityService : IActivityService
    {
        private readonly AppDbContext _db;

        public ActivityService(AppDbContext db)
        {
            _db = db;
        }
        public Result<List<ActivityResponse>> GetAll(ActivityType? type = null)
        {
            var activities = _db.Activities
                .Include(a => a.Registrations)
                .Where(a => a.IsActive && (type == null || a.Type == type))
                .Select(a => new ActivityResponse(
                    a.Id, a.Title, a.Description, a.Location,
                    a.StartDate, a.EndDate, a.Type.ToString(), a.ImageUrl,
                    a.MaxParticipants, a.MaxSpectators,
                    a.Registrations.Count(r => r.RegistrationType == RegistrationType.Participant),
                    a.Registrations.Count(r => r.RegistrationType == RegistrationType.Spectator),
                    a.IsActive, a.CompetitionType.ToString(), a.MaxTeamSize, a.MinTeamSize
                ))
                .ToList();

            return Result.Success(activities);
        }

        public Result<ActivityResponse> GetById(int id)
        {
            var a = _db.Activities
                .Include(a => a.Registrations)
                .FirstOrDefault(a => a.Id == id);

            if (a is null)
                return Result.Failure<ActivityResponse>("ღონისძიება ვერ მოიძებნა.");

            return Result.Success(new ActivityResponse(
                a.Id, a.Title, a.Description, a.Location,
                a.StartDate, a.EndDate, a.Type.ToString(), a.ImageUrl,
                a.MaxParticipants, a.MaxSpectators,
                a.Registrations.Count(r => r.RegistrationType == RegistrationType.Participant),
                a.Registrations.Count(r => r.RegistrationType == RegistrationType.Spectator),
                a.IsActive, a.CompetitionType.ToString(), a.MaxTeamSize, a.MinTeamSize
            ));
        }

        public Result<ActivityResponse> Create(CreateActivityRequest request)
        {
            if (request.Type == ActivityType.Competition && request.CompetitionType is null)
                return Result.Failure<ActivityResponse>("შეჯიბრებისთვის CompetitionType სავალდებულოა.");

            if (request.CompetitionType == CompetitionType.Team && (request.MaxTeamSize is null || request.MinTeamSize is null))
                return Result.Failure<ActivityResponse>("გუნდური შეჯიბრებისთვის MaxTeamSize და MinTeamSize სავალდებულოა.");

            var a = new Activity
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Type = request.Type,
                ImageUrl = request.ImageUrl,
                MaxParticipants = request.MaxParticipants,
                MaxSpectators = request.MaxSpectators,
                CompetitionType = request.CompetitionType,
                MaxTeamSize = request.MaxTeamSize,
                MinTeamSize = request.MinTeamSize
            };

            _db.Activities.Add(a);
            _db.SaveChanges();

            return Result.Success(new ActivityResponse(
                a.Id, a.Title, a.Description, a.Location,
                a.StartDate, a.EndDate, a.Type.ToString(), a.ImageUrl,
                a.MaxParticipants, a.MaxSpectators, 0, 0,
                a.IsActive, a.CompetitionType?.ToString(), a.MaxTeamSize, a.MinTeamSize
            ));
        }

        public Result<ActivityResponse> Update(int id, UpdateActivityRequest request)
        {
            var a = _db.Activities.Find(id);
            if (a is null)
                return Result.Failure<ActivityResponse>("ღონისძიება ვერ მოიძებნა.");

            if (request.Title is not null) a.Title = request.Title;
            if (request.Description is not null) a.Description = request.Description;
            if (request.Location is not null) a.Location = request.Location;
            if (request.StartDate.HasValue) a.StartDate = request.StartDate.Value;
            if (request.EndDate.HasValue) a.EndDate = request.EndDate.Value;
            if (request.ImageUrl is not null) a.ImageUrl = request.ImageUrl;
            if (request.MaxParticipants.HasValue) a.MaxParticipants = request.MaxParticipants.Value;
            if (request.MaxSpectators.HasValue) a.MaxSpectators = request.MaxSpectators.Value;
            if (request.IsActive.HasValue) a.IsActive = request.IsActive.Value;

            _db.SaveChanges();

            return Result.Success(new ActivityResponse(
                a.Id, a.Title, a.Description, a.Location,
                a.StartDate, a.EndDate, a.Type.ToString(), a.ImageUrl,
                a.MaxParticipants, a.MaxSpectators, 0, 0,
                a.IsActive, a.CompetitionType?.ToString(), a.MaxTeamSize, a.MinTeamSize
            ));
        }

        public Result Delete(int id)
        {
            var a = _db.Activities.Find(id);
            if (a is null)
                return Result.Failure("ღონისძიება ვერ მოიძებნა.");

            _db.Activities.Remove(a);
            _db.SaveChanges();
            return Result.Success();
        }
    }
}
