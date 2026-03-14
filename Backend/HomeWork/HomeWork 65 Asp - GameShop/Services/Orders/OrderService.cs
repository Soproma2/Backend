using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Data;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_65_Asp___GameShop.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public Result<OrderResponse> Checkout(int userId)
        {
            var cart = _context.Carts
                .Include(c => c.Items).ThenInclude(i => i.Game)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null || !cart.Items.Any())
                return Result<OrderResponse>.BadRequest("Cart is empty");

            var order = new Order
            {
                UserId = userId,
                TotalPrice = cart.Items.Sum(i => i.Game.Price),
                Items = cart.Items.Select(i => new OrderItem
                {
                    GameId = i.GameId,
                    PriceAtPurchase = i.Game.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.Items);
            _context.SaveChanges();

            var saved = _context.Orders
                .Include(o => o.Items).ThenInclude(i => i.Game)
                .FirstOrDefault(o => o.Id == order.Id);

            return Result<OrderResponse>.success("Purchase successful", ToResponse(saved));
        }

        public Result<List<OrderResponse>> GetMyOrders(int userId)
        {
            var orders = _context.Orders
                .Include(o => o.Items).ThenInclude(i => i.Game)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();

            if (!orders.Any())
                return Result<List<OrderResponse>>.NotFound("No orders found");

            return Result<List<OrderResponse>>.success(null, orders.Select(ToResponse).ToList());
        }

        public Result<List<OrderResponse>> GetAll()
        {
            var orders = _context.Orders
                .Include(o => o.Items).ThenInclude(i => i.Game)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();

            if (!orders.Any())
                return Result<List<OrderResponse>>.NotFound("No orders found");

            return Result<List<OrderResponse>>.success(null, orders.Select(ToResponse).ToList());
        }

        private static OrderResponse ToResponse(Order order) => new OrderResponse
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(i => new OrderItemResponse
            {
                GameId = i.GameId,
                GameTitle = i.Game.Title,
                PriceAtPurchase = i.PriceAtPurchase
            }).ToList()
        };
    }
}
