using HomeWork_61_Asp___Restaurant.Enums;

namespace HomeWork_61_Asp___Restaurant.DTOs.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderedAt { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
