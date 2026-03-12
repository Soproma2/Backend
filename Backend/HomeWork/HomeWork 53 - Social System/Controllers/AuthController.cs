using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_53___Social_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        public IActionResult Register(RegisterReq req)
        {
            var result = _authService.Register(req);
            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        [ProducesResponseType(typeof(Result<string>), 404)]
        public IActionResult Login(LoginReq req)
        {
            var result = _authService.Login(req);
            return StatusCode(result.Status, result);
        }
    }
}
