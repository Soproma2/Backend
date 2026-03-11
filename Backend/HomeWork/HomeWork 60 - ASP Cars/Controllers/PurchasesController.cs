using HomeWork_60___ASP_Cars.Enums;
using HomeWork_60___ASP_Cars.Services.PurchaseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_60___ASP_Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost("{carId}")]
        [Authorize(Roles = nameof(UserRole.Buyer))]
        public IActionResult Buy(int carId)
        {
            var buyerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _purchaseService.Buy(carId, buyerId);
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.Buyer))]
        public IActionResult GetMyPurchases()
        {
            var buyerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _purchaseService.GetMyPurchases(buyerId);
            return StatusCode(result.Status, result);
        }
    }
}
