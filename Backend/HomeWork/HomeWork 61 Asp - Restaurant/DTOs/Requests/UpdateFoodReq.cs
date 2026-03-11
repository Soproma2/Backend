namespace HomeWork_61_Asp___Restaurant.DTOs.Requests
{
    public class UpdateFoodReq
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
