using Homework_67_Asp___CompanyEvents.DTOs.Requests.Activities;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Services.ActivityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_67_Asp___CompanyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService) => _activityService = activityService;

        [HttpGet]
        public IActionResult GetAll([FromQuery] ActivityType? type)
        {
            var result = _activityService.GetAll(type);
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _activityService.GetById(id);
            if (!result.IsSuccess) return NotFound(result.Error);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateActivityRequest request)
        {
            var result = _activityService.Create(request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateActivityRequest request)
        {
            var result = _activityService.Update(id, request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _activityService.Delete(id);
            if (!result.IsSuccess) return NotFound(result.Error);
            return NoContent();
        }
    }
}
