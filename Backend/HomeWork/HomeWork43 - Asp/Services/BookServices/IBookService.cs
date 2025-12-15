using HomeWork43___Asp.DTOs;
using HomeWork43___Asp.Models;

namespace HomeWork43___Asp.Services.BookServices
{
    public interface IBookService
    {
        void Create(BookDto req);
        List<Book> Get();
        string Update(int bookId,UpdateDto req);
        void Delete(int bookId);
    }
}
