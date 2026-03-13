using HomeWork_63___Movie_Streaming_.Data;
using HomeWork_63___Movie_Streaming_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Services
{
    internal class UserService
    {
        private readonly StreamingDbContext _context;

        public UserService(StreamingDbContext context) => _context = context;

        // მომხმარებლის დამატება
        public async Task<User> CreateUserAsync(string username, string email)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                RegisteredAt = DateTime.Now
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // მომხმარებლის სრული ინფო
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Watchlists).ThenInclude(w => w.Movie)
                .Include(u => u.UserSubscriptions).ThenInclude(us => us.Subscription)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        // ფილმის Watchlist-ში დამატება — Many-to-Many #3
        public async Task AddToWatchlistAsync(int userId, int movieId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists) throw new ArgumentException($"მომხმარებელი ID-ით {userId} ვერ მოიძებნა.");

            var movieExists = await _context.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists) throw new ArgumentException($"ფილმი ID-ით {movieId} ვერ მოიძებნა.");

            var exists = await _context.Watchlists
                .AnyAsync(w => w.UserId == userId && w.MovieId == movieId);
            if (exists) throw new InvalidOperationException("ფილმი უკვე სიაშია.");

            _context.Watchlists.Add(new Watchlist
            {
                UserId = userId,
                MovieId = movieId,
                AddedAt = DateTime.Now,
                IsWatched = false
            });
            await _context.SaveChangesAsync();
        }

        // ფილმის ნანახად მონიშვნა + შეფასება
        public async Task MarkAsWatchedAsync(int userId, int movieId, int rating)
        {
            var entry = await _context.Watchlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.MovieId == movieId);
            if (entry == null) throw new InvalidOperationException("ფილმი სიაში არ არის.");

            entry.IsWatched = true;
            entry.UserRating = rating;
            await _context.SaveChangesAsync();
        }

        // გამოწერის მინიჭება — Many-to-Many #5
        public async Task AddSubscriptionAsync(
            int userId, int subscriptionId, DateTime startDate, DateTime endDate)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists) throw new ArgumentException($"მომხმარებელი ID-ით {userId} ვერ მოიძებნა.");

            var subscriptionExists = await _context.Subscriptions.AnyAsync(s => s.Id == subscriptionId);
            if (!subscriptionExists) throw new ArgumentException($"გამოწერა ID-ით {subscriptionId} ვერ მოიძებნა.");

            _context.UserSubscriptions.Add(new UserSubscription
            {
                UserId = userId,
                SubscriptionId = subscriptionId,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = true
            });
            await _context.SaveChangesAsync();
        }
    }
}
