using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.Data;
using HomeWork_53___Social_System.Models;

namespace HomeWork_53___Social_System.Services.LikeServices
{
    public class LikeService : ILikeService
    {
        private readonly AppDbContext _context;

        public LikeService(AppDbContext context)
        {
            _context = context;
        }

        public Result<string> Toggle(int postId, int userId)
        {
            if (postId <= 0)
                return Result<string>.BadRequest("Invalid post ID");

            var post = _context.Posts.Find(postId);
            if (post == null)
                return Result<string>.NotFound("Post not found");

            if (post.UserId == userId)
                return Result<string>.BadRequest("You cannot like your own post");

            var existing = _context.Likes
                .FirstOrDefault(l => l.PostId == postId && l.UserId == userId);

            if (existing != null)
            {
                _context.Likes.Remove(existing);
                _context.SaveChanges();
                return Result<string>.success("Post unliked", null);
            }

            _context.Likes.Add(new Like { PostId = postId, UserId = userId });
            _context.SaveChanges();
            return Result<string>.success("Post liked", null);
        }
    }
}
