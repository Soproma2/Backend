using HomeWork_59_ASP_GetEndpoints.Data;
using HomeWork_59_ASP_GetEndpoints.DTOs;
using HomeWork_59_ASP_GetEndpoints.Models;

namespace HomeWork_59_ASP_GetEndpoints.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public List<BookResponse> GetAll()
            => _context.Books.Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Year = b.Year,
                IsAvailable = b.IsAvailable
            }).ToList();

        public BookResponse? GetById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return null;
            return ToResponse(book);
        }

        public List<BookResponse> Search(string query)
            => _context.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query))
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Year = b.Year,
                    IsAvailable = b.IsAvailable
                }).ToList();

        public List<BookResponse> GetAvailable()
            => _context.Books
                .Where(b => b.IsAvailable)
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Year = b.Year,
                    IsAvailable = b.IsAvailable
                }).ToList();

        public List<BookResponse> GetByYear(int year)
            => _context.Books
                .Where(b => b.Year == year)
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Year = b.Year,
                    IsAvailable = b.IsAvailable
                }).ToList();

        public BookResponse Create(CreateBookReq req)
        {
            var book = new Book
            {
                Title = req.Title,
                Author = req.Author,
                Year = req.Year,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return ToResponse(book);
        }

        private static BookResponse ToResponse(Book book) => new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year,
            IsAvailable = book.IsAvailable
        };
    }
}
