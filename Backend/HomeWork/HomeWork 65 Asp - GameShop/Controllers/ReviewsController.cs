using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Enums;
using HomeWork_65_Asp___GameShop.Services.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_65_Asp___GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService) => _reviewService = reviewService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpGet("game/{gameId}")]
        [ProducesResponseType(typeof(Result<List<ReviewResponse>>), 200)]
        public IActionResult GetByGame(int gameId)
        {
            var result = _reviewService.GetByGame(gameId);
            return StatusCode(result.Status, result);
        }

        [HttpPost("{gameId}")]
        [Authorize(Roles = nameof(UserRole.User))]
        [ProducesResponseType(typeof(Result<ReviewResponse>), 200)]
        [ProducesResponseType(typeof(Result<ReviewResponse>), 400)]
        public IActionResult Create(int gameId, [FromBody] CreateReviewReq req)
        {
            var result = _reviewService.Create(gameId, req, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{reviewId}")]
        [Authorize(Roles = nameof(UserRole.User))]
        [ProducesResponseType(typeof(Result<ReviewResponse>), 200)]
        [ProducesResponseType(typeof(Result<ReviewResponse>), 404)]
        public IActionResult Delete(int reviewId)
        {
            var result = _reviewService.Delete(reviewId, GetUserId());
            return StatusCode(result.Status, result);
        }
    }
}
