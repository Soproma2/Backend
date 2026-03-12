using HomeWork_61_Asp___Restaurant.Common;
using HomeWork_61_Asp___Restaurant.Data;
using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.DTOs.Responses;
using HomeWork_61_Asp___Restaurant.Enums;
using HomeWork_61_Asp___Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_61_Asp___Restaurant.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public Result<OrderResponse> Create(CreateOrderReq req, int userId)
        {
            if (req.Items == null || !req.Items.Any())
                return Result<OrderResponse>.BadRequest("Order must have at least one item");

            if (req.Items.Any(i => i.Quantity <= 0))
                return Result<OrderResponse>.BadRequest("Quantity must be greater than 0");

            foreach (var item in req.Items)
            {
                var food = _context.Foods.Find(item.FoodId);
                if (food == null)
                    return Result<OrderResponse>.NotFound($"Food item {item.FoodId} not found");
                if (!food.IsAvailable)
                    return Result<OrderResponse>.BadRequest($"{food.Name} is not available");
            }

            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                Items = req.Items.Select(i => new OrderItem
                {
                    FoodId = i.FoodId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            var saved = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .FirstOrDefault(o => o.Id == order.Id);

            return Result<OrderResponse>.success("Order created successfully", ToResponse(saved));
        }

        public Result<OrderResponse> UpdateStatus(int id, OrderStatus status)
        {
            if (id <= 0)
                return Result<OrderResponse>.BadRequest("Invalid ID");

            var order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return Result<OrderResponse>.NotFound("Order not found");

            if (order.Status == OrderStatus.Cancelled)
                return Result<OrderResponse>.BadRequest("Cannot update a cancelled order");

            if (order.Status == OrderStatus.Delivered)
                return Result<OrderResponse>.BadRequest("Cannot update a delivered order");

            order.Status = status;
            _context.SaveChanges();

            return Result<OrderResponse>.success("Status updated successfully", ToResponse(order));
        }

        public Result<OrderResponse> Cancel(int id, int userId)
        {
            if (id <= 0)
                return Result<OrderResponse>.BadRequest("Invalid ID");

            var order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return Result<OrderResponse>.NotFound("Order not found");

            if (order.UserId != userId)
                return Result<OrderResponse>.BadRequest("You can only cancel your own orders");

            if (order.Status == OrderStatus.Delivered)
                return Result<OrderResponse>.BadRequest("Cannot cancel a delivered order");

            if (order.Status == OrderStatus.Cancelled)
                return Result<OrderResponse>.BadRequest("Order is already cancelled");

            order.Status = OrderStatus.Cancelled;
            _context.SaveChanges();

            return Result<OrderResponse>.success("Order cancelled successfully", ToResponse(order));
        }

        public Result<List<OrderResponse>> GetAll()
        {
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .ToList();

            if (!orders.Any())
                return Result<List<OrderResponse>>.NotFound("No orders found");

            return Result<List<OrderResponse>>.success(null, orders.Select(ToResponse).ToList());
        }

        public Result<List<OrderResponse>> GetMyOrders(int userId)
        {
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .Where(o => o.UserId == userId)
                .ToList();

            if (!orders.Any())
                return Result<List<OrderResponse>>.NotFound("No orders found");

            return Result<List<OrderResponse>>.success(null, orders.Select(ToResponse).ToList());
        }

        public Result<OrderResponse> GetById(int id)
        {
            if (id <= 0)
                return Result<OrderResponse>.BadRequest("Invalid ID");

            var order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items).ThenInclude(i => i.Food)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return Result<OrderResponse>.NotFound("Order not found");

            return Result<OrderResponse>.success(null, ToResponse(order));
        }

        private static OrderResponse ToResponse(Order order) => new OrderResponse
        {
            Id = order.Id,
            CustomerName = order.User.FullName,
            OrderedAt = order.OrderedAt,
            Status = order.Status,
            Items = order.Items.Select(i => new OrderItemResponse
            {
                FoodName = i.Food.Name,
                Quantity = i.Quantity,
                Price = i.Food.Price
            }).ToList(),
            TotalPrice = order.Items.Sum(i => i.Food.Price * i.Quantity)
        };
    }
}
