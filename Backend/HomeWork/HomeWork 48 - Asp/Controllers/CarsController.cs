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
    }
}
