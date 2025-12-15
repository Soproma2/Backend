using HomeWork43___Asp.Data;
using HomeWork43___Asp.DTOs;
using HomeWork43___Asp.Models;

namespace HomeWork43___Asp.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly DataContext _db;
        public BookService(DataContext db) => _db = db;
        public void Create(BookDto req)
        {
            Book book = new Book()
            {
                Title = req.Title,
                Description = req.Description,
                Author = req.Author,
            };

            _db.books.Add(book);
            _db.SaveChanges();
        }
    }
}
