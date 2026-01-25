using HomeWork_52___Asp_angular__movies_.DTOs.Request;
using HomeWork_52___Asp_angular__movies_.Services.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_52___Asp_angular__movies_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService) => _moviesService = moviesService;
       
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieDto req)
        {
            var result = _moviesService.CreateMovie(req);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(UpdateMovieDto req, int movieId)
        {
            var result = _moviesService.UpdateMovie(req, movieId);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovie(int movieId)
        {
            var result = _moviesService.DeleteMovie(movieId);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var result = _moviesService.GetAllMovies();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            var result = _moviesService.GetMoviesById(movieId);
            return StatusCode(result.Status, result);
        }
    }
}
