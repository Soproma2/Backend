using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Responses;
using HomeWork_65_Asp___GameShop.Enums;
using HomeWork_65_Asp___GameShop.Services.Orders;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService) => _orderService = orderService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpPost("checkout")]
        [Authorize(Roles = nameof(UserRole.User))]
        [ProducesResponseType(typeof(Result<OrderResponse>), 200)]
        [ProducesResponseType(typeof(Result<OrderResponse>), 400)]
        public IActionResult Checkout()
        {
            var result = _orderService.Checkout(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.User))]
        [ProducesResponseType(typeof(Result<List<OrderResponse>>), 200)]
        public IActionResult GetMyOrders()
        {
            var result = _orderService.GetMyOrders(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Admin))]
        [ProducesResponseType(typeof(Result<List<OrderResponse>>), 200)]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            return StatusCode(result.Status, result);
        }
    }
}
