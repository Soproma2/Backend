using HomeWork_52___Asp_angular__movies_.Common;
using HomeWork_52___Asp_angular__movies_.Data;
using HomeWork_52___Asp_angular__movies_.DTOs.Request;
using HomeWork_52___Asp_angular__movies_.DTOs.Response;
using HomeWork_52___Asp_angular__movies_.Models;

namespace HomeWork_52___Asp_angular__movies_.Services.Movies
{
    public class MovieServices : IMoviesService
    {
        private readonly DataContext _db;
        public MovieServices(DataContext db )
        {
            _db = db;
        }

        public Result<string> CreateMovie(CreateMovieDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
            {
                return Result<string>.BadRequest("Title is required");
            }

            if (string.IsNullOrWhiteSpace(req.Description))
            {
                return Result<string>.BadRequest("Description is required");
            }

            if (string.IsNullOrWhiteSpace(req.Genre))
            {
                return Result<string>.BadRequest("Genre is required");
            }

            if (req.Year == default)
            {
                return Result<string>.BadRequest("Year is required");
            }

            if (string.IsNullOrWhiteSpace(req.Director))
            {
                return Result<string>.BadRequest("Director is required");
            }

            if (!req.Rating.HasValue)
            {
                return Result<string>.BadRequest("Rating is required");
            }

            Movie movie = new Movie()
            {
                Title = req.Title,
                Description = req.Description,
                Genre = req.Genre,
                Year = req.Year,
                Director = req.Director,
                Rating = req.Rating
            };

            _db.Movies.Add(movie);
            _db.SaveChanges();

            return Result<string>.success("Movie added successfully.", null);
        }

        public Result<string> DeleteMovie(string id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return Result<string>.NotFound("Movie not found");
            }

            _db.Movies.Remove(movie);
            _db.SaveChanges();

            return Result<string>.success("Movie deleted successfully", null);
        }

        public Result<List<MovieResponse>> GetAllMovies()
        {
            var movies = _db.Movies.ToList();
            if(!movies.Any())
            {
                return Result<List<MovieResponse>>.BadRequest("Movies not found");
            }
            var response = movies.Select(m => new MovieResponse()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                Year = m.Year,
                Director = m.Director,
                Rating = m.Rating

            }).ToList();
            return Result<List<MovieResponse>>.success(null, response);
        }

        public Result<MovieResponse> GetMoviesById()
        {
            throw new NotImplementedException();
        }

        public Result<string> UpdateMovie(UpdateMovieDto req)
        {
            throw new NotImplementedException();
        }
    }
}
