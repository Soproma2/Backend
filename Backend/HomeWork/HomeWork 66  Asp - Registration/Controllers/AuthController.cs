using HomeWork_66__Asp___Registration.Common;
using HomeWork_66__Asp___Registration.DTOs.Requests;
using HomeWork_66__Asp___Registration.DTOs.Responses;
using HomeWork_66__Asp___Registration.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_66__Asp___Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);


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


        [HttpPost("verify-email")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        public IActionResult VerifyEmail(VerifyEmailReq req)
        {
            var result = _authService.VerifyEmail(req);
            return StatusCode(result.Status, result);
        }


        [HttpPost("forgot-password")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        public IActionResult ForgotPassword(ForgotPasswordReq req)
        {
            var result = _authService.ForgotPassword(req);
            return StatusCode(result.Status, result);
        }


        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        public IActionResult ResetPassword(ResetPasswordReq req)
        {
            var result = _authService.ResetPassword(req);
            return StatusCode(result.Status, result);
        }


        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(typeof(Result<UserResponse>), 200)]
        [ProducesResponseType(typeof(Result<UserResponse>), 404)]
        public IActionResult GetMe()
        {
            var result = _authService.GetMe(GetUserId());
            return StatusCode(result.Status, result);
        }
    }
}
