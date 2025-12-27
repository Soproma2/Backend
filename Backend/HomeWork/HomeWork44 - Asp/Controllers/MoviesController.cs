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
    }
}
