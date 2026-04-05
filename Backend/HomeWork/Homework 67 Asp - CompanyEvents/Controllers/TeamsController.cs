using Homework_67_Asp___CompanyEvents.DTOs.Requests.Teams;
using Homework_67_Asp___CompanyEvents.Services.TeamService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework_67_Asp___CompanyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService) => _teamService = teamService;
        private int CurrentUserId =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public IActionResult Create([FromBody] CreateTeamRequest request)
        {
            var result = _teamService.CreateTeam(CurrentUserId, request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _teamService.GetById(id);
            if (!result.IsSuccess) return NotFound(result.Error);
            return Ok(result.Data);
        }

        [HttpGet("activity/{activityId}")]
        public IActionResult GetByActivity(int activityId)
        {
            var result = _teamService.GetByActivity(activityId);
            return Ok(result.Data);
        }

        [HttpPost("members")]
        public IActionResult AddMember([FromBody] AddTeamMemberRequest request)
        {
            var result = _teamService.AddMember(CurrentUserId, request);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return Ok();
        }

        [HttpDelete("{teamId}/members/{userId}")]
        public IActionResult RemoveMember(int teamId, int userId)
        {
            var result = _teamService.RemoveMember(CurrentUserId, teamId, userId);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return NoContent();
        }

        [HttpDelete("{teamId}")]
        public IActionResult Delete(int teamId)
        {
            var result = _teamService.DeleteTeam(CurrentUserId, teamId);
            if (!result.IsSuccess) return BadRequest(result.Error);
            return NoContent();
        }
    }
}
