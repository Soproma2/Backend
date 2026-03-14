namespace HomeWork_65_Asp___GameShop.DTOs.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
