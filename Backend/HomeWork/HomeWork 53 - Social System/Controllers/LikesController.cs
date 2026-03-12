using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.Services.LikeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_53___Social_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        public LikesController(ILikeService likeService) => _likeService = likeService;


        [HttpPost("{postId}")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 400)]
        [ProducesResponseType(typeof(Result<string>), 404)]
        public IActionResult Toggle(int postId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _likeService.Toggle(postId, userId);
            return StatusCode(result.Status, result);
        }
    }
}
