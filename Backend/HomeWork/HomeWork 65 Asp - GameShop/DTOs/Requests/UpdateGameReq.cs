namespace HomeWork_65_Asp___GameShop.DTOs.Requests
{
    public class UpdateGameReq
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Platform { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
