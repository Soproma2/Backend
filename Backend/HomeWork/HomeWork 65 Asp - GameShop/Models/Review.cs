using HomeWork_65_Asp___GameShop.Common;

namespace HomeWork_65_Asp___GameShop.Models
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
