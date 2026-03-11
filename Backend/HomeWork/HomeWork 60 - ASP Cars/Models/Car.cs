using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_60___ASP_Cars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string FuelType { get; set; }
        public int Mileage { get; set; }
        public bool IsSold { get; set; } = false;
        public int SellerId { get; set; }
        public User Seller { get; set; }
    }
}
