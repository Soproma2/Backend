using Homework_67_Asp___CompanyEvents.DTOs.Requests.Auth;
using Homework_67_Asp___CompanyEvents.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_67_Asp___CompanyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var result = _authService.Register(request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _authService.Login(request);
            if (!result.IsSuccess) return Unauthorized(result.Error);
            return Ok(result.Data);
        }
    }
}
