using HomeWork43___Asp.Data;
using HomeWork43___Asp.DTOs;
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
    }
}
