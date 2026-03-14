using HomeWork_65_Asp___GameShop.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public List<Review> Reviews { get; set; } = new();
    }
}
