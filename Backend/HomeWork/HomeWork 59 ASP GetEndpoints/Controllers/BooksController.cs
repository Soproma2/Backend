using HomeWork_59_ASP_GetEndpoints.DTOs;
using HomeWork_59_ASP_GetEndpoints.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_59_ASP_GetEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            if (!result.Any()) return NotFound("No books found");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);
            if (result == null) return NotFound("Book not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return BadRequest("Search term is required");
            var result = _bookService.Search(query);
            if (!result.Any()) return NotFound("No books found");
            return Ok(result);
        }

        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            var result = _bookService.GetAvailable();
            if (!result.Any()) return NotFound("No available books found");
            return Ok(result);
        }

        [HttpGet("year/{year}")]
        public IActionResult GetByYear(int year)
        {
            if (year == default || year > DateTime.Now.Year) return BadRequest("Invalid year");
            var result = _bookService.GetByYear(year);
            if (!result.Any()) return NotFound("No books found for this year");
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(CreateBookReq req)
        {
            var result = _bookService.Create(req);
            return Ok(result);
        }
    }
}
