using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.Data;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;
using HomeWork_53___Social_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_53___Social_System.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public Result<CommentResponse> Create(int postId, CreateCommentReq req, int userId)
        {
            if (postId <= 0)
                return Result<CommentResponse>.BadRequest("Invalid post ID");

            if (string.IsNullOrWhiteSpace(req.Text))
                return Result<CommentResponse>.BadRequest("Text is required");

            var post = _context.Posts.Find(postId);
            if (post == null)
                return Result<CommentResponse>.NotFound("Post not found");

            var comment = new Comment
            {
                text = req.Text,
                PostId = postId,
                UserId = userId
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            var saved = _context.Comments
                .Include(c => c.user)
                .FirstOrDefault(c => c.Id == comment.Id);

            return Result<CommentResponse>.success("Comment added", ToResponse(saved));
        }

        public Result<CommentResponse> Delete(int commentId, int userId)
        {
            if (commentId <= 0)
                return Result<CommentResponse>.BadRequest("Invalid comment ID");

            var comment = _context.Comments.Find(commentId);
            if (comment == null)
                return Result<CommentResponse>.NotFound("Comment not found");

            if (comment.UserId != userId)
                return Result<CommentResponse>.BadRequest("You can only delete your own comments");

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Result<CommentResponse>.success("Comment deleted", null);
        }

        public Result<List<CommentResponse>> GetByPost(int postId)
        {
            if (postId <= 0)
                return Result<List<CommentResponse>>.BadRequest("Invalid post ID");

            var post = _context.Posts.Find(postId);
            if (post == null)
                return Result<List<CommentResponse>>.NotFound("Post not found");

            var comments = _context.Comments
                .Include(c => c.user)
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CreateAt)
                .Select(c => new CommentResponse
                {
                    Id = c.Id,
                    Text = c.text,
                    AuthorName = c.user.UserName,
                    CreatedAt = c.CreateAt
                }).ToList();

            if (!comments.Any())
                return Result<List<CommentResponse>>.NotFound("No comments found");

            return Result<List<CommentResponse>>.success(null, comments);
        }

        private static CommentResponse ToResponse(Comment comment) => new CommentResponse
        {
            Id = comment.Id,
            Text = comment.text,
            AuthorName = comment.user.UserName,
            CreatedAt = comment.CreateAt
        };
    }
}
