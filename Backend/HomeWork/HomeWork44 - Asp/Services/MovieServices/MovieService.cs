using HomeWork44___Asp.Data;
using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.DTOs.Responses;
using HomeWork44___Asp.Models;

namespace HomeWork44___Asp.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _db;
        public MovieService(DataContext db) => _db = db;

        public MovieResponse AddMovie(CreateRequest req)
        {
            Movie movie = new Movie()
            {
                Title = req.Title,
                Description = req.Description,
                CreatedDate = req.CreatedDate,
                Duration = req.Duration
            };

            _db.Movies.Add(movie);
            _db.SaveChanges();
            return new MovieResponse()
            {
                Id = movie.Id,
                Description = movie.Description,
                CreatedDate = movie.CreatedDate,
                Duration = movie.Duration
            };
        }

        public MovieResponse? DeleteMovie(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return null;

            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return new MovieResponse()
            {
                Id = movie.Id,
                Description = movie.Description,
                CreatedDate = movie.CreatedDate,
                Duration = movie.Duration
            };
        }

        public List<MovieResponse>? GetAllMovie()
        {
            var response = _db.Movies.Select(e => new MovieResponse()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                CreatedDate = e.CreatedDate,
                Duration = e.Duration
            }).ToList();

            if(response == null) return null;

            return response;
        }

        public MovieResponse? GetMovieById(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return null;

            return new MovieResponse()
            {
                Id = id,
                Description = movie.Description,
                CreatedDate = movie.CreatedDate,
                Duration = movie.Duration
            };
        }

        public MovieResponse? UpdateMovie(int id, UpdateRequest req)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return null;

            if (!string.IsNullOrWhiteSpace(req.Title))
                movie.Title = req.Title;
            if (!string.IsNullOrWhiteSpace(req.Description))
                movie.Description = req.Description;
            if (req.CreatedDate.HasValue)
                movie.CreatedDate = req.CreatedDate.Value;
            if (req.Duration.HasValue)
            movie.Duration = req.Duration.Value;

            _db.SaveChanges();
            return new MovieResponse()
            {
                Id = movie.Id,
                Description = movie.Description,
                CreatedDate = movie.CreatedDate,
                Duration = movie.Duration
            };
        }
    }
}
