using HomeWork39.DTOs;
using HomeWork39.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork39.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostSystemController : ControllerBase
    {
        private List<Post> posts = new List<Post>();
        [HttpGet]
        public List<Post> GetAllPosts()
        {
            return posts;
        }

        [HttpGet("Post/{postId}")]
        public string GetPostByID(int postID)
        {
            var post = posts.FirstOrDefault(x => x.Id == postID);
            return $"Requested post ID: {postID}";
        }

        [HttpGet("FilterPost/{ByTitle}")]
        public string FilterPostByTitle(string ByTitle)
        {
            var result = posts.Where(x =>
            x.Title.ToLower().Contains(ByTitle.ToLower())).ToList();

            return $"Requested post Title: {ByTitle}";
        }

        [HttpPost]
        public string CreatePost(PostDTO dto)
        {
            Post post = new Post()
            {
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author
            };

            return "Post created successfully.";
        }
    }
}
