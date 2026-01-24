namespace HomeWork_52___Asp_angular__movies_.DTOs.Request
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public decimal? Rating { get; set; }
    }
}
