using HomeWork_59_ASP_GetEndpoints.DTOs;
using HomeWork_59_ASP_GetEndpoints.Models;

namespace HomeWork_59_ASP_GetEndpoints.Services
{
    public interface IBookService
    {
        List<BookResponse> GetAll();
        BookResponse? GetById(int id);
        List<BookResponse> Search(string query);
        List<BookResponse> GetAvailable();
        List<BookResponse> GetByYear(int year);
        BookResponse Create(CreateBookReq req);
    }
}
