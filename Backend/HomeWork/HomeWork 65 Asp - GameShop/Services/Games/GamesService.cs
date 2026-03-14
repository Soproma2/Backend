using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Data;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_65_Asp___GameShop.Services.Games
{
    public class GamesService : IGamesService
    {
        private readonly AppDbContext _context;

        public GamesService(AppDbContext context)
        {
            _context = context;
        }

        public Result<GameResponse> Create(CreateGameReq req, int sellerId)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<GameResponse>.BadRequest("Title is required");

            if (string.IsNullOrWhiteSpace(req.Genre))
                return Result<GameResponse>.BadRequest("Genre is required");

            if (string.IsNullOrWhiteSpace(req.Platform))
                return Result<GameResponse>.BadRequest("Platform is required");

            if (req.Price <= 0)
                return Result<GameResponse>.BadRequest("Price must be greater than 0");

            if (_context.Games.Any(g => g.Title == req.Title && g.SellerId == sellerId))
                return Result<GameResponse>.BadRequest("You already have a game with this title");

            var game = new Game
            {
                Title = req.Title,
                Description = req.Description,
                Genre = req.Genre,
                Platform = req.Platform,
                ImageUrl = req.ImageUrl,
                Price = req.Price,
                SellerId = sellerId
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            return Result<GameResponse>.success("Game created successfully", ToResponse(game));
        }

        public Result<GameResponse> Update(int id, UpdateGameReq req, int sellerId)
        {
            if (id <= 0)
                return Result<GameResponse>.BadRequest("Invalid ID");

            var game = _context.Games.Find(id);
            if (game == null)
                return Result<GameResponse>.NotFound("Game not found");

            if (game.SellerId != sellerId)
                return Result<GameResponse>.BadRequest("You can only edit your own games");

            if (req.Price.HasValue && req.Price <= 0)
                return Result<GameResponse>.BadRequest("Price must be greater than 0");

            game.Title = req.Title ?? game.Title;
            game.Description = req.Description ?? game.Description;
            game.Genre = req.Genre ?? game.Genre;
            game.Platform = req.Platform ?? game.Platform;
            game.ImageUrl = req.ImageUrl ?? game.ImageUrl;
            game.Price = req.Price ?? game.Price;
            game.IsAvailable = req.IsAvailable ?? game.IsAvailable;
            game.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return Result<GameResponse>.success("Game updated successfully", ToResponse(game));
        }

        public Result<GameResponse> Delete(int id, int sellerId)
        {
            if (id <= 0)
                return Result<GameResponse>.BadRequest("Invalid ID");

            var game = _context.Games.Find(id);
            if (game == null)
                return Result<GameResponse>.NotFound("Game not found");

            if (game.SellerId != sellerId)
                return Result<GameResponse>.BadRequest("You can only delete your own games");

            _context.Games.Remove(game);
            _context.SaveChanges();
            return Result<GameResponse>.success("Game deleted successfully", null);
        }

        public Result<List<GameResponse>> GetAll()
        {
            var games = _context.Games
                .Include(g => g.Seller)
                .Include(g => g.Reviews)
                .Where(g => g.IsAvailable)
                .Select(g => new GameResponse
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Genre = g.Genre,
                    Platform = g.Platform,
                    ImageUrl = g.ImageUrl,
                    Price = g.Price,
                    IsAvailable = g.IsAvailable,
                    SellerName = g.Seller.UserName,
                    AverageRating = g.Reviews.Any() ? g.Reviews.Average(r => r.Rating) : 0,
                    ReviewCount = g.Reviews.Count
                }).ToList();

            if (!games.Any())
                return Result<List<GameResponse>>.NotFound("No games found");

            return Result<List<GameResponse>>.success(null, games);
        }

        public Result<GameResponse> GetById(int id)
        {
            if (id <= 0)
                return Result<GameResponse>.BadRequest("Invalid ID");

            var game = _context.Games
                .Include(g => g.Seller)
                .Include(g => g.Reviews)
                .FirstOrDefault(g => g.Id == id);

            if (game == null)
                return Result<GameResponse>.NotFound("Game not found");

            return Result<GameResponse>.success(null, ToResponse(game));
        }

        public Result<List<GameResponse>> GetMyGames(int sellerId)
        {
            var games = _context.Games
                .Include(g => g.Seller)
                .Include(g => g.Reviews)
                .Where(g => g.SellerId == sellerId)
                .Select(g => new GameResponse
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Genre = g.Genre,
                    Platform = g.Platform,
                    ImageUrl = g.ImageUrl,
                    Price = g.Price,
                    IsAvailable = g.IsAvailable,
                    SellerName = g.Seller.UserName,
                    AverageRating = g.Reviews.Any() ? g.Reviews.Average(r => r.Rating) : 0,
                    ReviewCount = g.Reviews.Count
                }).ToList();

            if (!games.Any())
                return Result<List<GameResponse>>.NotFound("No games found");

            return Result<List<GameResponse>>.success(null, games);
        }

        public Result<List<GameResponse>> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Result<List<GameResponse>>.BadRequest("Search term is required");

            var games = _context.Games
                .Include(g => g.Seller)
                .Include(g => g.Reviews)
                .Where(g => g.IsAvailable && (g.Title.Contains(query) || g.Genre.Contains(query)))
                .Select(g => new GameResponse
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Genre = g.Genre,
                    Platform = g.Platform,
                    ImageUrl = g.ImageUrl,
                    Price = g.Price,
                    IsAvailable = g.IsAvailable,
                    SellerName = g.Seller.UserName,
                    AverageRating = g.Reviews.Any() ? g.Reviews.Average(r => r.Rating) : 0,
                    ReviewCount = g.Reviews.Count
                }).ToList();

            if (!games.Any())
                return Result<List<GameResponse>>.NotFound("No games found");

            return Result<List<GameResponse>>.success(null, games);
        }

        public Result<List<GameResponse>> Filter(string? genre, string? platform, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Games
                .Include(g => g.Seller)
                .Include(g => g.Reviews)
                .Where(g => g.IsAvailable);

            if (!string.IsNullOrWhiteSpace(genre))
                query = query.Where(g => g.Genre.ToLower() == genre.ToLower());

            if (!string.IsNullOrWhiteSpace(platform))
                query = query.Where(g => g.Platform.ToLower() == platform.ToLower());

            if (minPrice.HasValue)
                query = query.Where(g => g.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(g => g.Price <= maxPrice);

            var games = query.Select(g => new GameResponse
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Genre = g.Genre,
                Platform = g.Platform,
                ImageUrl = g.ImageUrl,
                Price = g.Price,
                IsAvailable = g.IsAvailable,
                SellerName = g.Seller.UserName,
                AverageRating = g.Reviews.Any() ? g.Reviews.Average(r => r.Rating) : 0,
                ReviewCount = g.Reviews.Count
            }).ToList();

            if (!games.Any())
                return Result<List<GameResponse>>.NotFound("No games found");

            return Result<List<GameResponse>>.success(null, games);
        }

        private static GameResponse ToResponse(Game game) => new GameResponse
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Genre = game.Genre,
            Platform = game.Platform,
            ImageUrl = game.ImageUrl,
            Price = game.Price,
            IsAvailable = game.IsAvailable,
            SellerName = game.Seller?.UserName,
            AverageRating = game.Reviews.Any() ? game.Reviews.Average(r => r.Rating) : 0,
            ReviewCount = game.Reviews.Count
        };
    }
}
