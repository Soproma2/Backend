namespace HomeWork44___Asp.DTOs.Requests
{
    public class CreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Duration { get; set; }
    }
}
