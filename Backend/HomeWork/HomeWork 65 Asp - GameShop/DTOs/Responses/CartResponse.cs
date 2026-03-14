namespace HomeWork_65_Asp___GameShop.DTOs.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public List<CartItemResponse> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
