namespace HomeWork_60___ASP_Cars.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int BuyerId { get; set; }
        public User Buyer { get; set; }
        public DateTime PurchasedAt { get; set; } = DateTime.Now;
    }
}
