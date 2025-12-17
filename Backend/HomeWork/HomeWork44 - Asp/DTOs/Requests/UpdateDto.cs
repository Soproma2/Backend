namespace HomeWork44___Asp.DTOs.Requests
{
    public class UpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
