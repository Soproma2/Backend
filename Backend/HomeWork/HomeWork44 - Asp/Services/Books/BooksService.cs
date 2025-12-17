using HomeWork44___Asp.Data;
using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.DTOs.Responses;

namespace HomeWork44___Asp.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly DataContext _db;

        public BooksService(DataContext db) => _db = db;
        public BookResponse CreateBook(CreateDto req)
        {
            throw new NotImplementedException();
        }
    }
}
