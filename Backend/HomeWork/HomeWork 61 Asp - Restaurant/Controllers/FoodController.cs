using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.Enums;
using HomeWork_61_Asp___Restaurant.Services.FoodService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_61_Asp___Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _foodService.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var result = _foodService.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("category/{category}")]
        [Authorize]
        public IActionResult GetByCategory(string category)
        {
            var result = _foodService.GetByCategory(category);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Create(CreateFoodReq req)
        {
            var result = _foodService.Create(req);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Update(int id, UpdateFoodReq req)
        {
            var result = _foodService.Update(id, req);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Delete(int id)
        {
            var result = _foodService.Delete(id);
            return StatusCode(result.Status, result);
        }
    }
}
