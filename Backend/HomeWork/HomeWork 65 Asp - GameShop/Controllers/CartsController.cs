using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Enums;
using HomeWork_65_Asp___GameShop.Services.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_65_Asp___GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserRole.User))]
    [Produces("application/json")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService) => _cartService = cartService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpGet]
        [ProducesResponseType(typeof(Result<CartResponse>), 200)]
        public IActionResult GetMyCart()
        {
            var result = _cartService.GetMyCart(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPost("{gameId}")]
        [ProducesResponseType(typeof(Result<CartResponse>), 200)]
        [ProducesResponseType(typeof(Result<CartResponse>), 400)]
        public IActionResult AddItem(int gameId)
        {
            var result = _cartService.AddItem(gameId, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(typeof(Result<CartResponse>), 200)]
        [ProducesResponseType(typeof(Result<CartResponse>), 404)]
        public IActionResult RemoveItem(int gameId)
        {
            var result = _cartService.RemoveItem(gameId, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpDelete("clear")]
        [ProducesResponseType(typeof(Result<CartResponse>), 200)]
        public IActionResult Clear()
        {
            var result = _cartService.Clear(GetUserId());
            return StatusCode(result.Status, result);
        }
    }
}
