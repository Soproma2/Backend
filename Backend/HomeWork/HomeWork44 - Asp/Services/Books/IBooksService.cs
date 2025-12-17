using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.DTOs.Responses;
using HomeWork44___Asp.Models;

namespace HomeWork44___Asp.Services.Books
{
    public interface IBooksService
    {
        BookResponse CreateBook(CreateDto req);
    }
}
