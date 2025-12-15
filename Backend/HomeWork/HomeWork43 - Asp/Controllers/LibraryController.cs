using HomeWork43___Asp.Data;
using HomeWork43___Asp.DTOs;
using HomeWork43___Asp.Models;
using HomeWork43___Asp.Services.BookServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork43___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
       private readonly IBookService _bs;
        public LibraryController(IBookService bs)
        {
            _bs = bs;
        }

        [HttpPost]
        public IActionResult Create(BookDto req)
        {
            _bs.Create(req);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = _bs.Get();
            return Ok(res);
        }

        [HttpPut("Book/{bookId}")]
        public IActionResult Put(int bookId,UpdateDto req)
        {
            _bs.Update(bookId, req);
            return Ok();
        }

        [HttpDelete("book/{bookId}")]
        public IActionResult Delete(int bookId)
        {
            _bs.Delete(bookId);
            return Ok();
        }
    }
}
