using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_47___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _us;
        public UsersController(IUserService us)
        {
            _us = us;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _us.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult RegisterUser(UserCreateReq req)
        {
            var user = _us.RegisterUser(req);
            return Ok(user);
        }
    }
}
