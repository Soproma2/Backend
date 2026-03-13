using HomeWork_64_Asp___Todo.Common;
using HomeWork_64_Asp___Todo.DTOs.Requests;
using HomeWork_64_Asp___Todo.DTOs.Responses;
using HomeWork_64_Asp___Todo.Services.Todo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_64_Asp___Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _TS;

        public TodosController(ITodoService ts) => _TS = ts;

        [HttpPost]
        public IActionResult CreateTodo(CreateTodoReq req)
        {
            var result = _TS.Create(req);
            return StatusCode(result.Status, result);
        }

        [HttpPut]
        public IActionResult UpdateTodo([FromQuery]int Id, UpdateTodoReq req)
        {
            var result = _TS.Update(Id,req);
            return StatusCode(result.Status, result);
        }

        [HttpPost("Toggle")]
        public IActionResult Toggle([FromQuery]int Id)
        {
            var result = _TS.ToggleComplete(Id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _TS.GetAll();
            return StatusCode(result.Status, result);
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var result = _TS.GetById(Id);
            return StatusCode(result.Status, result);
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery]int Id)
        {
            var result = _TS.Delete(Id);
            return StatusCode(result.Status, result);
        }
    }
}
