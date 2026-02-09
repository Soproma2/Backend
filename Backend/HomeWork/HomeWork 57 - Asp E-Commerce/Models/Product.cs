using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.Enums;

namespace HomeWork_57___Asp_E_Commerce.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; } = Category.Other;

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<OrderItem> Orderitems { get; set; } = new List<OrderItem>();

    }
}
