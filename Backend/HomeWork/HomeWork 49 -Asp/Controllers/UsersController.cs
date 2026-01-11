using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.Services.UserServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HomeWork_49__Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetUserById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, EditUserRequest req)
        {
            var result = _userService.EditUser(id, req);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            return StatusCode(result.Status, result);
        }

        [HttpPut("Change-Password/{id}")]
        public IActionResult ChangeUserPassword(int id, ChangePasswordRequest req)
        {
            var result = _userService.ChangePassword(id, req);
            return StatusCode(result.Status, result);
        }
    }
}
