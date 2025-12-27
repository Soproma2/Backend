using HomeWork44___Asp.DTOs.Requests;
using HomeWork44___Asp.DTOs.Responses;

namespace HomeWork44___Asp.Services.MovieServices
{
    public interface IMovieService
    {
        List<MovieResponse>? GetAllMovie();
        MovieResponse? GetMovieById(int id);
        MovieResponse AddMovie(CreateRequest req);
        MovieResponse? UpdateMovie(int id, UpdateRequest req);
        MovieResponse? DeleteMovie(int id);
    }
}
