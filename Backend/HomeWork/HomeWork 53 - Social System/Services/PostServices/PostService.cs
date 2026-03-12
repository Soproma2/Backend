using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.Data;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;
using HomeWork_53___Social_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_53___Social_System.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public Result<PostResponse> Create(CreatePostReq req, int userId)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<PostResponse>.BadRequest("Title is required");

            if (string.IsNullOrWhiteSpace(req.Description))
                return Result<PostResponse>.BadRequest("Description is required");

            var post = new Post
            {
                Title = req.Title,
                description = req.Description,
                imgUrl = req.ImgUrl,
                UserId = userId
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            var saved = _context.Posts
                .Include(p => p.user)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == post.Id);

            return Result<PostResponse>.success("Post created successfully", ToResponse(saved));
        }

        public Result<PostResponse> Delete(int postId, int userId)
        {
            if (postId <= 0)
                return Result<PostResponse>.BadRequest("Invalid post ID");

            var post = _context.Posts.Find(postId);
            if (post == null)
                return Result<PostResponse>.NotFound("Post not found");

            if (post.UserId != userId)
                return Result<PostResponse>.BadRequest("You can only delete your own posts");

            var comments = _context.Comments.Where(c => c.PostId == postId);
            _context.Comments.RemoveRange(comments);


            var likes = _context.Likes.Where(l => l.PostId == postId);
            _context.Likes.RemoveRange(likes);

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return Result<PostResponse>.success("Post deleted successfully", null);
        }

        public Result<List<PostResponse>> GetAll()
        {
            var posts = _context.Posts
                .Include(p => p.user)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.CreateAt)
                .Select(p => new PostResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.description,
                    ImgUrl = p.imgUrl,
                    AuthorName = p.user.UserName,
                    LikeCount = p.Likes.Count,
                    CommentCount = p.Comments.Count,
                    CreatedAt = p.CreateAt
                }).ToList();

            if (!posts.Any())
                return Result<List<PostResponse>>.NotFound("No posts found");

            return Result<List<PostResponse>>.success(null, posts);
        }

        public Result<PostResponse> GetById(int postId)
        {
            if (postId <= 0)
                return Result<PostResponse>.BadRequest("Invalid post ID");

            var post = _context.Posts
                .Include(p => p.user)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == postId);

            if (post == null)
                return Result<PostResponse>.NotFound("Post not found");

            return Result<PostResponse>.success(null, ToResponse(post));
        }

        public Result<List<PostResponse>> GetMyPosts(int userId)
        {
            var posts = _context.Posts
                .Include(p => p.user)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreateAt)
                .Select(p => new PostResponse
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.description,
                    ImgUrl = p.imgUrl,
                    AuthorName = p.user.UserName,
                    LikeCount = p.Likes.Count,
                    CommentCount = p.Comments.Count,
                    CreatedAt = p.CreateAt
                }).ToList();

            if (!posts.Any())
                return Result<List<PostResponse>>.NotFound("No posts found");

            return Result<List<PostResponse>>.success(null, posts);
        }

        private static PostResponse ToResponse(Post post) => new PostResponse
        {
            Id = post.Id,
            Title = post.Title,
            Description = post.description,
            ImgUrl = post.imgUrl,
            AuthorName = post.user.UserName,
            LikeCount = post.Likes.Count,
            CommentCount = post.Comments.Count,
            CreatedAt = post.CreateAt
        };
    }
}
