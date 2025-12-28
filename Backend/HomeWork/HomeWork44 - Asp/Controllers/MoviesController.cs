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


        [HttpPut("movie/{id}")]
        public IActionResult UpdateMovie(int id,UpdateRequest req)
        {
            var movie = _ms.UpdateMovie(id, req);
            return Ok(movie);
        }

        [HttpDelete("movie/{id}")]
        public IActionResult DeleteById(int id)
        {
            var movie = _ms.DeleteMovie(id);
            return Ok(movie);
        }

    }
}
