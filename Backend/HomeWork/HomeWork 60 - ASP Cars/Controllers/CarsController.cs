using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.Enums;
using HomeWork_60___ASP_Cars.Services.CarService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_60___ASP_Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("search")]
        [Authorize]
        public IActionResult Search([FromQuery] string query)
        {
            var result = _carService.Search(query);
            return StatusCode(result.Status, result);
        }

        [HttpGet("filter")]
        [Authorize]
        public IActionResult Filter([FromQuery] string? brand, [FromQuery] int? year,
            [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? fuelType)
        {
            var result = _carService.Filter(brand, year, minPrice, maxPrice, fuelType);
            return StatusCode(result.Status, result);
        }

        [HttpGet("my")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        public IActionResult GetMyCars()
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _carService.GetMyCars(sellerId);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Seller))]
        public IActionResult Create(CreateCarReq req)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _carService.Create(req, sellerId);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        public IActionResult Update(int id, UpdateCarReq req)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _carService.Update(id, req, sellerId);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Seller))]
        public IActionResult Delete(int id)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = _carService.Delete(id, sellerId);
            return StatusCode(result.Status, result);
        }
    }
}
