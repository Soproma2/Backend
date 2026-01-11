using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.Services.AuthServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_49__Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;


        [HttpPost("register")]
        public IActionResult Register(RegisterRequest req)
        {
            var result = _authService.Register(req);
            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest req)
        {
            var result = _authService.Login(req);
            return StatusCode(result.Status, result);
        }
    }   
}
