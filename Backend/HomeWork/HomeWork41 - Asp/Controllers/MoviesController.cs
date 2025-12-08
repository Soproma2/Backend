using HomeWork41___Asp.Data;
using HomeWork41___Asp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork41___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _db;
        public MoviesController(DataContext db) { _db = db; }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var data = _db.Movies.ToList();
            return Ok(data);
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> GetMoviesById(int movieId)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Id == movieId);
            if (data == null) return NotFound("movie not found!");
            return Ok(data);
        }


        [HttpGet("{author")]
        public IActionResult GetMoviesByAuthor(string author)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Author == author);
            if (data == null) return NotFound("movies not found!");
            return Ok(data);
        }

        [HttpGet("{rating}")]
        public IActionResult GetMoviesByRating(double rating)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Rating == rating);
            if (data == null) return NotFound("movies not found!");
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateMovie(DTOs.MoviesDto req)
        {
            Movie movie = new Movie()
            {
                Title = req.Title,
                Description = req.Description,
                Author = req.Author,
                Rating = req.Rating,
                Duration = req.Duration,
                PublishedAt = req.PublishedAt
            };
            _db.Movies.Add(movie);
            return Ok(movie);
        }

        [HttpPut("{MovieId}")]
        public IActionResult UpdateMoviesById(int MovieId, DTOs.MoviesDto req)
        {
            var data = _db.Movies.Find(MovieId);

            data.Id = MovieId;
            if (req.Title != null) data.Title == req.Title;

        }
    }
}
