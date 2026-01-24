using HomeWork_52___Asp_angular__movies_.Common;
using HomeWork_52___Asp_angular__movies_.DTOs.Request;
using HomeWork_52___Asp_angular__movies_.DTOs.Response;

namespace HomeWork_52___Asp_angular__movies_.Services.Movies
{
    public interface IMoviesService
    {
        Result<MovieResponse> GetAllMovies();
        Result<MovieResponse> GetMoviesById();
        Result<string> CreateMovie(CreateMovieDto req);
        Result<string> UpdateMovie(UpdateMovieDto req);
        Result<string> DeleteMovie(string id);
    }
}
