using HomeWork_65_Asp___GameShop.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtPurchase { get; set; }
    }
}
