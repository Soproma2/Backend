using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_65_Asp___GameShop.Controllers
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
        public IActionResult Login(LoginReq req)
        {
            var result = _authService.Login(req);
            return StatusCode(result.Status, result);
        }
    }
}
