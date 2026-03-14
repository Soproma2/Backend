namespace HomeWork_65_Asp___GameShop.DTOs.Requests
{
    public class CreateGameReq
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
