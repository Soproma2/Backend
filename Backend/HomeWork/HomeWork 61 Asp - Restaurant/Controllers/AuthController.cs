using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_61_Asp___Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterReq req)
        {
            var result = _authService.Register(req);
            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReq req)
        {
            var result = _authService.Login(req);
            return StatusCode(result.Status, result);
        }
    }
}
