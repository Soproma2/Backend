using HomeWork_46___Asp.DTOs.Requests;
using HomeWork_46___Asp.Services.BookServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_46___Asp.Controllers
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
        [HttpPost]
        public IActionResult Create(CreateReq req)
        {
            var create = _bookService.CreateBook(req);
            return Ok(req);
        }

        [HttpPut("book/{Id}")]
        public IActionResult Update(int Id, UpdateReq req)
        {
            var update = _bookService.UpdateBook(Id,req);
            return Ok(update);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var get = _bookService.Get();
            return Ok(get);
        }

        [HttpDelete("Book/{Id}")]
        public IActionResult Delete(int Id)
        {
            var delete = _bookService.Delete(Id);
            return Ok(delete);
        }

        [HttpGet("book/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var ById = _bookService.GetById(Id);
            return Ok(ById);
        }

        [HttpGet]
        public IActionResult GetBytitleOrauthor(string search)
        {
            var ragaca = _bookService.GetBytitleOrauthor(search);
            return Ok(ragaca);
        }
    }
}
