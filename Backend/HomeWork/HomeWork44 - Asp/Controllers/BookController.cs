using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork44___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksService _bs;
        public BookController(IBooksService bs)
        {
            _bs = bs;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateDto req)
        {
            var result = _bs.CreateBook(req);
            return Ok(result);
        }
    }
}
