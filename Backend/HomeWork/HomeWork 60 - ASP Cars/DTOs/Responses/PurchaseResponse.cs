namespace HomeWork_60___ASP_Cars.DTOs.Responses
{
    public class PurchaseResponse
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public decimal Price { get; set; }
        public string SellerName { get; set; }
        public DateTime PurchasedAt { get; set; }
    }
}
