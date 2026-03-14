using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Completed;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
