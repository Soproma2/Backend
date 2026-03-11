using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_60___ASP_Cars.Controllers
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
