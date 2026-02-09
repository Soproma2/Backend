using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;
namespace HomeWork_57___Asp_E_Commerce.Services.Orders
{
    public interface IOrderService
    {
        Result<string> Checkout(User user);
        Result<OrderResponse> ViewOrderHistory(User user);
        Result<string> CancelOrder(User user);
        Result<List<OrderResponse>> ViewAllOrders();
        Result<string> MarkOrderDelivered();
        Result<string> AdminCancelOrder();
        Result<Order> ViewOrderDetails();
    }
}
