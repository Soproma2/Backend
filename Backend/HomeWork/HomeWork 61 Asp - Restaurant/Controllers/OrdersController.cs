using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.Enums;
using HomeWork_61_Asp___Restaurant.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_61_Asp___Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult GetMyOrders()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _orderService.GetMyOrders(userId);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult Create(CreateOrderReq req)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _orderService.Create(req, userId);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult UpdateStatus(int id, [FromBody] OrderStatus status)
        {
            var result = _orderService.UpdateStatus(id, status);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = nameof(UserRole.User))]
        public IActionResult Cancel(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _orderService.Cancel(id, userId);
            return StatusCode(result.Status, result);
        }
    }
}
