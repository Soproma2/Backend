namespace HomeWork_65_Asp___GameShop.DTOs.Responses
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
