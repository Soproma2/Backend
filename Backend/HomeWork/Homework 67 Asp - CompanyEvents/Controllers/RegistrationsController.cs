using Homework_67_Asp___CompanyEvents.DTOs.Requests.Registrations;
using Homework_67_Asp___CompanyEvents.Services.RegistrationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework_67_Asp___CompanyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationsController(IRegistrationService registrationService) => _registrationService = registrationService;
        private int CurrentUserId =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public IActionResult Register([FromBody] RegisterToActivityRequest request)
        {
            var result = _registrationService.Register(CurrentUserId, request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [HttpDelete("{activityId}")]
        public IActionResult Unregister(int activityId)
        {
            var result = _registrationService.Unregister(CurrentUserId, activityId);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return NoContent();
        }

        [HttpGet("my")]
        public IActionResult MyRegistrations()
        {
            var result = _registrationService.GetByUser(CurrentUserId);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("activity/{activityId}")]
        public IActionResult GetByActivity(int activityId)
        {
            var result = _registrationService.GetByActivity(activityId);
            return Ok(result.Data);
        }
    }
}
