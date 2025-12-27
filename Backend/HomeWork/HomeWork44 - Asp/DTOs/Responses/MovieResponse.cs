namespace HomeWork44___Asp.DTOs.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Duration { get; set; }
    }
}
