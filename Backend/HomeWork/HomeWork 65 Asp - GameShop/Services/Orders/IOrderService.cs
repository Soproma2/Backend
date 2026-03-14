using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Responses;

namespace HomeWork_65_Asp___GameShop.Services.Orders
{
    public interface IOrderService
    {
        Result<OrderResponse> Checkout(int userId);
        Result<List<OrderResponse>> GetMyOrders(int userId);
        Result<List<OrderResponse>> GetAll();
    }
}
