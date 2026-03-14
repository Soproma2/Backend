using HomeWork_65_Asp___GameShop.Enums;

namespace HomeWork_65_Asp___GameShop.DTOs.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }
}
