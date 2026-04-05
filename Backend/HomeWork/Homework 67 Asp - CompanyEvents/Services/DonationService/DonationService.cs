using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.Data;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Donations;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Donations;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_67_Asp___CompanyEvents.Services.DonationService
{
    public class DonationService : IDonationService
    {
        private readonly AppDbContext _db;

        public DonationService(AppDbContext db)
        {
            _db = db;
        }

        public Result<DonationResponse> CreateDonation(int userId, CreateDonationRequest request)
        {
            if (request.Amount <= 0)
                return Result.Failure<DonationResponse>("თანხა უნდა იყოს დადებითი.");

            if (request.ActivityId.HasValue && !_db.Activities.Any(a => a.Id == request.ActivityId.Value))
                return Result.Failure<DonationResponse>("ღონისძიება ვერ მოიძებნა.");

            var donation = new Donation
            {
                UserId = userId,
                Amount = request.Amount,
                DonationType = request.DonationType,
                Purpose = request.Purpose,
                ActivityId = request.ActivityId,
                Status = DonationStatus.Active,
                NextBillingDate = request.DonationType == DonationType.Subscription
                    ? DateTime.UtcNow.AddMonths(1)
                    : null
            };

            _db.Donations.Add(donation);
            _db.SaveChanges();

            var result = _db.Donations
                .Include(d => d.User)
                .Include(d => d.Activity)
                .Where(d => d.Id == donation.Id)
                .Select(d => new DonationResponse(
                    d.Id, d.UserId, d.User.FullName,
                    d.Amount, d.DonationType.ToString(), d.Status.ToString(),
                    d.Purpose, d.ActivityId, d.Activity != null ? d.Activity.Title : null,
                    d.CreatedAt, d.NextBillingDate
                ))
                .First();

            return Result.Success(result);
        }

        public Result CancelSubscription(int userId, int donationId)
        {
            var donation = _db.Donations.Find(donationId);
            if (donation is null)
                return Result.Failure("დონაცია ვერ მოიძებნა.");

            if (donation.UserId != userId)
                return Result.Failure("წვდომა აკრძალულია.");

            if (donation.DonationType != DonationType.Subscription)
                return Result.Failure("ეს ერთჯერადი დონაციაა.");

            if (donation.Status == DonationStatus.Cancelled)
                return Result.Failure("გამოწერა უკვე გაუქმებულია.");

            donation.Status = DonationStatus.Cancelled;
            donation.CancelledAt = DateTime.UtcNow;
            _db.SaveChanges();
            return Result.Success();
        }

        public Result<List<DonationResponse>> GetByUser(int userId)
        {
            var list = _db.Donations
                .Include(d => d.User)
                .Include(d => d.Activity)
                .Where(d => d.UserId == userId)
                .OrderByDescending(d => d.CreatedAt)
                .Select(d => new DonationResponse(
                    d.Id, d.UserId, d.User.FullName,
                    d.Amount, d.DonationType.ToString(), d.Status.ToString(),
                    d.Purpose, d.ActivityId, d.Activity != null ? d.Activity.Title : null,
                    d.CreatedAt, d.NextBillingDate
                ))
                .ToList();

            return Result.Success(list);
        }

        public Result<List<DonationResponse>> GetAll()
        {
            var list = _db.Donations
                .Include(d => d.User)
                .Include(d => d.Activity)
                .OrderByDescending(d => d.CreatedAt)
                .Select(d => new DonationResponse(
                    d.Id, d.UserId, d.User.FullName,
                    d.Amount, d.DonationType.ToString(), d.Status.ToString(),
                    d.Purpose, d.ActivityId, d.Activity != null ? d.Activity.Title : null,
                    d.CreatedAt, d.NextBillingDate
                ))
                .ToList();

            return Result.Success(list);
        }

        public void ProcessSubscriptions()
        {
            var due = _db.Donations
                .Where(d => d.DonationType == DonationType.Subscription
                         && d.Status == DonationStatus.Active
                         && d.NextBillingDate <= DateTime.UtcNow)
                .ToList();

            foreach (var sub in due)
                sub.NextBillingDate = DateTime.UtcNow.AddMonths(1);

            _db.SaveChanges();
        }
    }
}
