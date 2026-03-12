using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;
using HomeWork_53___Social_System.Services.CommentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_53___Social_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService) => _commentService = commentService;


        [HttpGet("post/{postId}")]
        [ProducesResponseType(typeof(Result<List<CommentResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<CommentResponse>>), 400)]
        [ProducesResponseType(typeof(Result<List<CommentResponse>>), 404)]
        public IActionResult GetByPost(int postId)
        {
            var result = _commentService.GetByPost(postId);
            return StatusCode(result.Status, result);
        }


        [HttpPost("{postId}")]
        [ProducesResponseType(typeof(Result<CommentResponse>), 200)]
        [ProducesResponseType(typeof(Result<CommentResponse>), 400)]
        [ProducesResponseType(typeof(Result<CommentResponse>), 404)]
        public IActionResult Create(int postId, [FromBody] CreateCommentReq req)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _commentService.Create(postId, req, userId);
            return StatusCode(result.Status, result);
        }


        [HttpDelete("{commentId}")]
        [ProducesResponseType(typeof(Result<CommentResponse>), 200)]
        [ProducesResponseType(typeof(Result<CommentResponse>), 400)]
        [ProducesResponseType(typeof(Result<CommentResponse>), 404)]
        public IActionResult Delete(int commentId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _commentService.Delete(commentId, userId);
            return StatusCode(result.Status, result);
        }
    }
}
