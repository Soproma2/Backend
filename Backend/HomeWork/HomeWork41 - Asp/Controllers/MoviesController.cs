using HomeWork41___Asp.Data;
using HomeWork41___Asp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeWork41___Asp.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

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

        [HttpGet("details/{movieId}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> GetMoviesById(int movieId)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Id == movieId);
            if (data == null) return NotFound("movie not found!");
            return Ok(data);
        }


        [HttpGet("{author}")]
        public IActionResult GetMoviesByAuthor(string author)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Author == author);
            if (data == null) return NotFound("movies not found!");
            return Ok(data);
        }

        [HttpGet("movies/{rating}")]
        public IActionResult GetMoviesByRating(double rating)
        {
            var data = _db.Movies.FirstOrDefault(e => e.Rating == rating);
            if (data == null) return NotFound("movies not found!");
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateMovie(CreateDtoMovie req)
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
            _db.SaveChanges();
            return Ok(movie);
        }

        [HttpPut("Update/{MovieId}")]
        public IActionResult UpdateMoviesById(int MovieId, UpdateDtoMovies req)
        {
            var data = _db.Movies.Find(MovieId);
            if (data == null) return NotFound();


            if (!string.IsNullOrWhiteSpace(req.Title)) data.Title = req.Title;
            if (!string.IsNullOrWhiteSpace(req.Description)) data.Description = req.Description;
            if (req.PublishedAt.HasValue) data.PublishedAt = req.PublishedAt.Value;
            if (!string.IsNullOrWhiteSpace(req.Author)) data.Author = req.Author;
            if (req.Duration.HasValue) data.Duration = req.Duration.Value;
            if (req.Rating.HasValue) data.Rating = req.Rating.Value;

            _db.SaveChanges();
            return Ok(data);
        }

        [HttpDelete("{MovieId}")]
        public IActionResult DeleteMoviesById(int MovieId)
        {
            var data = _db.Movies.Find(MovieId);
            if (data == null) return NotFound();

            _db.Movies.Remove(data);
            _db.SaveChanges();
            return Ok(data);
        }
    }
}
