using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.DTOs.Requests.BookRequests;
using Homework_58_ASP___Library.DTOs.Responses;

namespace Homework_58_ASP___Library.Services.BookService
{
    public interface IBookService
    {
        public interface IBookService
        {
            Result<BookResponse> CreateBook(AddBookReq req);
            Result<BookResponse> UpdateBook(int id, EditBookReq req);
            Result<BookResponse> Delete(int id);
            Result<List<BookResponse>> Get();
            Result<BookResponse> GetById(int id);
            Result<List<BookResponse>> GetByTitleOrAuthor(string search);
        }
    }
}
