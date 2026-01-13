using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SocialMedia___Asp_50.Data;
using SocialMedia___Asp_50.DTOs;
using SocialMedia___Asp_50.Models;

namespace SocialMedia___Asp_50.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly DataContext _db;
        public BlogsController(DataContext db) => _db = db;

        [HttpPost]
        public IActionResult Create(CreateBlogDTO req)
        {
            if(string.IsNullOrWhiteSpace(req.Title))
                return BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(req.Description))
                return BadRequest("Description is required");

            if (string.IsNullOrWhiteSpace(req.ImgUrl))
                return BadRequest("Image url is required");


            Blog blog = new Blog()
            {
                Name = req.Title,
                ImageUrl = req.ImgUrl,
                Description = req.Description
            };

            _db. Blogs.Add(blog);
            _db.SaveChanges();


            return Ok();

        }

        [HttpGet]
        public IActionResult Get()
        {
            var blogs = _db.Blogs.ToList();

            return Ok(blogs);
        }
    }
}
