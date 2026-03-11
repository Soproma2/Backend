namespace HomeWork_60___ASP_Cars.DTOs.Requests
{
    public class CreateCarReq
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
        public int Mileage { get; set; }
    }
}
