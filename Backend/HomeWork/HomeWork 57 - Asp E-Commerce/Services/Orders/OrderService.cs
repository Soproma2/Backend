using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;

namespace HomeWork_57___Asp_E_Commerce.Services.Orders
{
    public class OrderService : IOrderService
    {
        public Result<string> AdminCancelOrder()
        {
            throw new NotImplementedException();
        }

        public Result<string> CancelOrder(User user)
        {
            throw new NotImplementedException();
        }

        public Result<string> Checkout(User user)
        {
            throw new NotImplementedException();
        }

        public Result<string> MarkOrderDelivered()
        {
            throw new NotImplementedException();
        }

        public Result<List<OrderResponse>> ViewAllOrders()
        {
            throw new NotImplementedException();
        }

        public Result<Order> ViewOrderDetails()
        {
            throw new NotImplementedException();
        }

        public Result<OrderResponse> ViewOrderHistory(User user)
        {
            throw new NotImplementedException();
        }
    }
}
