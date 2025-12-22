using HomeWork_46___Asp.Data;
using HomeWork_46___Asp.DTOs.Requests;
using HomeWork_46___Asp.DTOs.Responses;
using HomeWork_46___Asp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HomeWork_46___Asp.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly DataContext _db;
        public BookService(DataContext db)
        {
            _db = db;
        }
        public BookResponse CreateBook(CreateReq req)
        {
            Book book = new Book()
            {
                Title = req.Title,
                Description = req.Description,
                Author = req.Author
            };

            _db.books.Add(book);
            _db.SaveChanges();

            return new BookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author
            };

        }

        public BookResponse Delete(int Id)
        {
            var book = _db.books.Find(Id);
            if (book == null) return null;

            _db.books.Remove(book);
            _db.SaveChanges();

            return new BookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author
            };
        }

        public List<BookResponse> Get()
        {
            var respons = _db.books.Select(e => new BookResponse()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Author = e.Author
            }).ToList();

            return respons;

        }

        public BookResponse UpdateBook(int Id, UpdateReq req)
        {
            var book = _db.books.Find(Id);


            if (book == null) return null;

            if (!string.IsNullOrWhiteSpace(req.Title))
                book.Title = req.Title;

            if (!string.IsNullOrWhiteSpace(req.Description))
                book.Description = req.Description;

            if (!string.IsNullOrWhiteSpace(req.Author))
                book.Author = req.Author;

            _db.SaveChanges();

            return new BookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author
            };
        }

        public BookResponse GetById(int Id)
        {
            var book = _db.books.Find(Id);
            if (book == null) return null;

            return new BookResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author
            };
        }

        public List<BookResponse> GetBytitleOrauthor(string search)
        {
            var response = _db.books.Where(e=> e.Author == search || e.Title == search).Select(e=>new BookResponse()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Author = e.Author
            }).ToList();

            if (response == null) return null;

            return response;
        }
    }
}
