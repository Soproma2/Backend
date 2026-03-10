using Homework_58_ASP___Library.DTOs.Requests.BookRequests;
using Homework_58_ASP___Library.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Homework_58_ASP___Library.Services;

using Homework_58_ASP___Library.Services.BookService;

namespace Homework_58_ASP___Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = _bookService.Get();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("search")]
        [Authorize]
        public IActionResult Search([FromQuery] string search)
        {
            var result = _bookService.GetByTitleOrAuthor(search);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Create(AddBookReq req)
        {
            var result = _bookService.CreateBook(req);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Update(int id, EditBookReq req)
        {
            var result = _bookService.UpdateBook(id, req);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return StatusCode(result.Status, result);
        }
    }
}
