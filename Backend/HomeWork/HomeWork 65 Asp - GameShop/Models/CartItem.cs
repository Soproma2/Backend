using HomeWork_65_Asp___GameShop.Common;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
