using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Data;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_65_Asp___GameShop.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public Result<ReviewResponse> Create(int gameId, CreateReviewReq req, int userId)
        {
            if (gameId <= 0)
                return Result<ReviewResponse>.BadRequest("Invalid game ID");

            if (req.Rating < 1 || req.Rating > 5)
                return Result<ReviewResponse>.BadRequest("Rating must be between 1 and 5");

            var game = _context.Games.Find(gameId);
            if (game == null)
                return Result<ReviewResponse>.NotFound("Game not found");

            var hasPurchased = _context.Orders
                .Include(o => o.Items)
                .Any(o => o.UserId == userId && o.Items.Any(i => i.GameId == gameId));

            if (!hasPurchased)
                return Result<ReviewResponse>.BadRequest("You can only review games you have purchased");

            if (_context.Reviews.Any(r => r.GameId == gameId && r.UserId == userId))
                return Result<ReviewResponse>.BadRequest("You have already reviewed this game");

            var review = new Review
            {
                GameId = gameId,
                UserId = userId,
                Rating = req.Rating,
                Comment = req.Comment
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            var saved = _context.Reviews
                .Include(r => r.User)
                .FirstOrDefault(r => r.Id == review.Id);

            return Result<ReviewResponse>.success("Review added", ToResponse(saved));
        }

        public Result<ReviewResponse> Delete(int reviewId, int userId)
        {
            if (reviewId <= 0)
                return Result<ReviewResponse>.BadRequest("Invalid review ID");

            var review = _context.Reviews.Find(reviewId);
            if (review == null)
                return Result<ReviewResponse>.NotFound("Review not found");

            if (review.UserId != userId)
                return Result<ReviewResponse>.BadRequest("You can only delete your own reviews");

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return Result<ReviewResponse>.success("Review deleted", null);
        }

        public Result<List<ReviewResponse>> GetByGame(int gameId)
        {
            if (gameId <= 0)
                return Result<List<ReviewResponse>>.BadRequest("Invalid game ID");

            var game = _context.Games.Find(gameId);
            if (game == null)
                return Result<List<ReviewResponse>>.NotFound("Game not found");

            var reviews = _context.Reviews
                .Include(r => r.User)
                .Where(r => r.GameId == gameId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewResponse
                {
                    Id = r.Id,
                    UserName = r.User.UserName,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                }).ToList();

            if (!reviews.Any())
                return Result<List<ReviewResponse>>.NotFound("No reviews found");

            return Result<List<ReviewResponse>>.success(null, reviews);
        }

        private static ReviewResponse ToResponse(Review review) => new ReviewResponse
        {
            Id = review.Id,
            UserName = review.User.UserName,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt
        };
    }
}
