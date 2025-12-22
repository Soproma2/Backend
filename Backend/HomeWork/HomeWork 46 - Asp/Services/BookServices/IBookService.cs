using HomeWork_46___Asp.DTOs.Requests;
using HomeWork_46___Asp.DTOs.Responses;

namespace HomeWork_46___Asp.Services.BookServices
{
    public interface IBookService
    {
        BookResponse CreateBook(CreateReq req);
        BookResponse UpdateBook(int Id, UpdateReq req);
        BookResponse Delete(int Id);
        List<BookResponse> Get();
        BookResponse GetById(int Id);
        List<BookResponse> GetBytitleOrauthor(string search);
    }
}
