using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;

namespace HomeWork_53___Social_System.Services.CommentServices
{
    public interface ICommentService
    {
        Result<CommentResponse> Create(int postId, CreateCommentReq req, int userId);
        Result<CommentResponse> Delete(int commentId, int userId);
        Result<List<CommentResponse>> GetByPost(int postId);
    }
}
