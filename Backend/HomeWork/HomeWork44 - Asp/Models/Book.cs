using Azure.Core.Pipeline;

namespace HomeWork44___Asp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
