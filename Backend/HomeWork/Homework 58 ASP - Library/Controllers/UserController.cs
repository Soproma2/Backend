using Homework_58_ASP___Library.DTOs.Requests.UserRequests;
using Homework_58_ASP___Library.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_58_ASP___Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService authService)
        {
            _userService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserReq req)
        {
            var result = _userService.Register(req);
            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserReq req)
        {
            var result = _userService.Login(req);
            return StatusCode(result.Status, result);
        }
    }
}
