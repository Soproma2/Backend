using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.Data;
using Homework_58_ASP___Library.DTOs.Requests.BookRequests;
using Homework_58_ASP___Library.DTOs.Responses;
using Homework_58_ASP___Library.Models;

namespace Homework_58_ASP___Library.Services.BookService
{
    public class BookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public Result<BookResponse> CreateBook(AddBookReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<BookResponse>.BadRequest("Title is required");

            if (string.IsNullOrWhiteSpace(req.Author))
                return Result<BookResponse>.BadRequest("Author is required");

            if (req.Year == default || req.Year > DateTime.Now.Year)
                return Result<BookResponse>.BadRequest("Invalid year");

            var exists = _context.Books.Any(b => b.Title == req.Title && b.Author == req.Author);
            if (exists)
                return Result<BookResponse>.BadRequest("This book already exists");

            var book = new Book
            {
                Title = req.Title,
                Author = req.Author,
                Year = req.Year,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return Result<BookResponse>.success("Book created successfully", ToResponse(book));
        }

        public Result<BookResponse> UpdateBook(int id, EditBookReq req)
        {
            if (id <= 0)
                return Result<BookResponse>.BadRequest("Invalid ID");

            var book = _context.Books.Find(id);
            if (book == null)
                return Result<BookResponse>.NotFound("Book not found");

            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<BookResponse>.BadRequest("Title is required");

            if (string.IsNullOrWhiteSpace(req.Author))
                return Result<BookResponse>.BadRequest("Author is required");

            if (req.Year == default || req.Year > DateTime.Now.Year)
                return Result<BookResponse>.BadRequest("Invalid year");

            book.Title = req.Title;
            book.Author = req.Author;
            book.Year = req.Year.Value;

            _context.SaveChanges();
            return Result<BookResponse>.success("Book updated successfully", ToResponse(book));
        }

        public Result<BookResponse> Delete(int id)
        {
            if (id <= 0)
                return Result<BookResponse>.BadRequest("Invalid ID");

            var book = _context.Books.Find(id);
            if (book == null)
                return Result<BookResponse>.NotFound("Book not found");

            var hasActiveLoans = _context.Loans.Any(l => l.BookId == id && !l.IsReturned);
            if (hasActiveLoans)
                return Result<BookResponse>.BadRequest("Book is currently loaned out, cannot delete");

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Result<BookResponse>.success("Book deleted successfully", ToResponse(book));
        }

        public Result<List<BookResponse>> Get()
        {
            var books = _context.Books.Select(b => ToResponse(b)).ToList();

            if (!books.Any())
                return Result<List<BookResponse>>.NotFound("No books found");

            return Result<List<BookResponse>>.success(null, books);
        }

        public Result<BookResponse> GetById(int id)
        {
            if (id <= 0)
                return Result<BookResponse>.BadRequest("Invalid ID");

            var book = _context.Books.Find(id);
            if (book == null)
                return Result<BookResponse>.NotFound("Book not found");

            return Result<BookResponse>.success(null, ToResponse(book));
        }

        public Result<List<BookResponse>> GetByTitleOrAuthor(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Result<List<BookResponse>>.BadRequest("Search term is required");

            var books = _context.Books
                .Where(b => b.Title.Contains(search) || b.Author.Contains(search))
                .Select(b => ToResponse(b))
                .ToList();

            if (!books.Any())
                return Result<List<BookResponse>>.NotFound("No books found");

            return Result<List<BookResponse>>.success(null, books);
        }

        private BookResponse ToResponse(Book book) => new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year,
            IsAvailable = book.IsAvailable
        };
    }
}
