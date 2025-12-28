using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.Services.MovieServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork44___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _ms;
        public MoviesController(IMovieService ms)
        {
            _ms = ms;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _ms.GetAllMovie();
            return Ok(movies);
        }

        [HttpGet("movie/{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _ms.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie(CreateRequest req)
        {
            var movie = _ms.AddMovie(req);
            return Ok(movie);
        }


    }
}
