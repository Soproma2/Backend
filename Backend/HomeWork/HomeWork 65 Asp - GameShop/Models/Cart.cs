using HomeWork_65_Asp___GameShop.Common;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class Cart :BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> Items { get; set; } = new();
    }
}
