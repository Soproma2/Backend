using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.DTOs.Requests;
using HomeWork_56___Todo___Extension.DTOs.Responses;
using HomeWork_56___Todo___Extension.Enums;
using HomeWork_56___Todo___Extension.Services.ToDo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeWork_56___Todo___Extension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService) => _todoService = todoService;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpGet]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 404)]
        public IActionResult GetAll()
        {
            var result = _todoService.GetAll(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<TodoResponse>), 200)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 404)]
        public IActionResult GetById(int id)
        {
            var result = _todoService.GetById(id, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet("priority/{priority}")]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 404)]
        public IActionResult GetByPriority(Priority priority)
        {
            var result = _todoService.GetByPriority(priority, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet("completed")]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 404)]
        public IActionResult GetCompleted()
        {
            var result = _todoService.GetCompleted(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpGet("pending")]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 200)]
        [ProducesResponseType(typeof(Result<List<TodoResponse>>), 404)]
        public IActionResult GetPending()
        {
            var result = _todoService.GetPending(GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<TodoResponse>), 200)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 400)]
        public IActionResult Create(CreateTodoReq req)
        {
            var result = _todoService.Create(req, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Result<TodoResponse>), 200)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 400)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 404)]
        public IActionResult Update(int id, UpdateTodoReq req)
        {
            var result = _todoService.Update(id, req, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpPatch("{id}/toggle")]
        [ProducesResponseType(typeof(Result<TodoResponse>), 200)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 404)]
        public IActionResult Toggle(int id)
        {
            var result = _todoService.ToggleComplete(id, GetUserId());
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<TodoResponse>), 200)]
        [ProducesResponseType(typeof(Result<TodoResponse>), 404)]
        public IActionResult Delete(int id)
        {
            var result = _todoService.Delete(id, GetUserId());
            return StatusCode(result.Status, result);
        }
    }
}
