using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;
using HomeWork_53___Social_System.Services.PostServices;
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
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService) => _postService = postService;


        [HttpGet]
        [ProducesResponseType(typeof(Result<List<PostResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<PostResponse>>), 404)]
        public IActionResult GetAll()
        {
            var result = _postService.GetAll();
            return StatusCode(result.Status, result);
        }


        [HttpGet("{postId}")]
        [ProducesResponseType(typeof(Result<PostResponse>), 200)]
        [ProducesResponseType(typeof(Result<PostResponse>), 400)]
        [ProducesResponseType(typeof(Result<PostResponse>), 404)]
        public IActionResult GetById(int postId)
        {
            var result = _postService.GetById(postId);
            return StatusCode(result.Status, result);
        }


        [HttpGet("my")]
        [ProducesResponseType(typeof(Result<List<PostResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<PostResponse>>), 404)]
        public IActionResult GetMyPosts()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _postService.GetMyPosts(userId);
            return StatusCode(result.Status, result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Result<PostResponse>), 200)]
        [ProducesResponseType(typeof(Result<PostResponse>), 400)]
        public IActionResult Create([FromBody] CreatePostReq req)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _postService.Create(req, userId);
            return StatusCode(result.Status, result);
        }


        [HttpDelete("{postId}")]
        [ProducesResponseType(typeof(Result<PostResponse>), 200)]
        [ProducesResponseType(typeof(Result<PostResponse>), 400)]
        [ProducesResponseType(typeof(Result<PostResponse>), 404)]
        public IActionResult Delete(int postId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _postService.Delete(postId, userId);
            return StatusCode(result.Status, result);
        }
    }
}
