namespace HomeWork39.Models
{
    public class Post
    {
        private static int _counter = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Post() => Id = _counter++;
    }
}
