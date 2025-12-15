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

        public void Delete(int bookId)
        {
            var book = _db.books.Find(bookId);

            _db.books.Remove(book);
            _db.SaveChanges();
        }

        public List<Book> Get()
        {
            var books = _db.books.ToList();
            return books;
        }

        public string Update(int bookId,UpdateDto req)
        {
            var book = _db.books.Find(bookId);
            if (book == null) return "Book Not Found!";

            if(!string.IsNullOrWhiteSpace(req.Title)) book.Title = req.Title;
            if (!string.IsNullOrWhiteSpace(req.Description)) book.Description = req.Description;
            if (!string.IsNullOrWhiteSpace(req.Author)) book.Author = req.Author;

            _db.SaveChanges();
            return "Book Updated Successfully";
        }
    }
}
