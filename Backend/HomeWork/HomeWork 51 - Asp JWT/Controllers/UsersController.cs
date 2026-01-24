using HomeWork_51___Asp_JWT.DTOs;
using HomeWork_51___Asp_JWT.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_51___Asp_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        public UsersController(IAuthService authService) => _authService = authService;
        [HttpPost("register")]
        public IActionResult Register(RegisterDto req)
        {
            var result = _authService.Register(req);

            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto req)
        {
            var result = _authService.Login(req);

            return StatusCode(result.Status, result);
        }

        [HttpGet("{userId}")]
        public IActionResult getUserById(int userId)
        {
            var result = _authService.GetUserByid(userId);
            return StatusCode(result.Status, result);
        }
    }
}
