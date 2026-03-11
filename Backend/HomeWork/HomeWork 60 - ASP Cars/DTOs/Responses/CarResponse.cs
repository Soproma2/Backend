namespace HomeWork_60___ASP_Cars.DTOs.Responses
{
    public class CarResponse
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
        public int Mileage { get; set; }
        public bool IsSold { get; set; }
        public string SellerName { get; set; }
    }
}
