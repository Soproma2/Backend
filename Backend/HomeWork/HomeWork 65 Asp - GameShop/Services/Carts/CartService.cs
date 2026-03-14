using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Data;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_65_Asp___GameShop.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public Result<CartResponse> GetMyCart(int userId)
        {
            var cart = GetOrCreateCart(userId);
            return Result<CartResponse>.success(null, ToResponse(cart));
        }

        public Result<CartResponse> AddItem(int gameId, int userId)
        {
            if (gameId <= 0)
                return Result<CartResponse>.BadRequest("Invalid game ID");

            var game = _context.Games.Find(gameId);
            if (game == null)
                return Result<CartResponse>.NotFound("Game not found");

            if (!game.IsAvailable)
                return Result<CartResponse>.BadRequest("Game is not available");

            if (game.SellerId == userId)
                return Result<CartResponse>.BadRequest("You cannot buy your own game");

            var cart = GetOrCreateCart(userId);

            if (cart.Items.Any(i => i.GameId == gameId))
                return Result<CartResponse>.BadRequest("Game already in cart");

            var alreadyPurchased = _context.Orders
                .Include(o => o.Items)
                .Any(o => o.UserId == userId && o.Items.Any(i => i.GameId == gameId));

            if (alreadyPurchased)
                return Result<CartResponse>.BadRequest("You already own this game");

            cart.Items.Add(new CartItem { CartId = cart.Id, GameId = gameId });
            _context.SaveChanges();

            cart = GetOrCreateCart(userId);
            return Result<CartResponse>.success("Game added to cart", ToResponse(cart));
        }

        public Result<CartResponse> RemoveItem(int gameId, int userId)
        {
            var cart = GetOrCreateCart(userId);
            var item = cart.Items.FirstOrDefault(i => i.GameId == gameId);

            if (item == null)
                return Result<CartResponse>.NotFound("Game not in cart");

            _context.CartItems.Remove(item);
            _context.SaveChanges();

            cart = GetOrCreateCart(userId);
            return Result<CartResponse>.success("Game removed from cart", ToResponse(cart));
        }

        public Result<CartResponse> Clear(int userId)
        {
            var cart = GetOrCreateCart(userId);

            _context.CartItems.RemoveRange(cart.Items);
            _context.SaveChanges();

            cart = GetOrCreateCart(userId);
            return Result<CartResponse>.success("Cart cleared", ToResponse(cart));
        }

        private Cart GetOrCreateCart(int userId)
        {
            var cart = _context.Carts
                .Include(c => c.Items).ThenInclude(i => i.Game)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            return cart;
        }

        private static CartResponse ToResponse(Cart cart) => new CartResponse
        {
            Id = cart.Id,
            Items = cart.Items.Select(i => new CartItemResponse
            {
                Id = i.Id,
                GameId = i.GameId,
                GameTitle = i.Game.Title,
                ImageUrl = i.Game.ImageUrl,
                Price = i.Game.Price
            }).ToList(),
            TotalPrice = cart.Items.Sum(i => i.Game.Price)
        };
    }
}
