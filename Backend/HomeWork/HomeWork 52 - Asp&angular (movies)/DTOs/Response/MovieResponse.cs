namespace HomeWork_52___Asp_angular__movies_.DTOs.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
