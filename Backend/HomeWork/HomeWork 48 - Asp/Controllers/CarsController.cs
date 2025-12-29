using HomeWork_48___Asp.DTOs.Requests;
using HomeWork_48___Asp.Services.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_48___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _cs;
        public CarsController(ICarsService cs) => _cs = cs;

        [HttpPost]
        public IActionResult AddCar(CarCreateReq req)
        {
           var result =  _cs.AddCar(req);
           return StatusCode(result.Status, result);
        }

        [HttpDelete("car/{Id}")]
        public IActionResult DeleteCar(int Id)
        {
            var result = _cs.DeleteCar(Id);
            return StatusCode(result.Status, result);
        }

        [HttpGet("car/{Id}")]
        public IActionResult GetCarById(int Id)
        {
            var result = _cs.GetCarById(Id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var result = _cs.GetCars();
            return StatusCode(result.Status, result);
        }

        [HttpGet("Sorted")]
        public IActionResult SortCarByPrice()
        {
            var result = _cs.SortCarByPrice();
            return StatusCode(result.Status, result);
        }

        [HttpPut("car/{Id}")]
        public IActionResult UpdateCar(int Id, CarUpdateReq req)
        {
            var result = _cs.UpdateCar(Id, req);
            return StatusCode(result.Status, result);
        }
    }
}
