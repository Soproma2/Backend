using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.Enums;

namespace HomeWork_57___Asp_E_Commerce.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
