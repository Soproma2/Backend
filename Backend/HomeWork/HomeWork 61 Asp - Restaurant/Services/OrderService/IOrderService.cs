using HomeWork_61_Asp___Restaurant.Common;
using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.DTOs.Responses;
using HomeWork_61_Asp___Restaurant.Enums;

namespace HomeWork_61_Asp___Restaurant.Services.OrderService
{
    public interface IOrderService
    {
        Result<OrderResponse> Create(CreateOrderReq req, int userId);
        Result<OrderResponse> UpdateStatus(int id, OrderStatus status);
        Result<OrderResponse> Cancel(int id, int userId);
        Result<List<OrderResponse>> GetAll();
        Result<List<OrderResponse>> GetMyOrders(int userId);
        Result<OrderResponse> GetById(int id);
    }
}
