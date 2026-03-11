using HomeWork_61_Asp___Restaurant.Enums;

namespace HomeWork_61_Asp___Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem> Items { get; set; } = new();
    }
}
