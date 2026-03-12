using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;
using HomeWork_53___Social_System.DTOs.Responses;

namespace HomeWork_53___Social_System.Services.PostServices
{
    public interface IPostService
    {
        Result<PostResponse> Create(CreatePostReq req, int userId);
        Result<PostResponse> Delete(int postId, int userId);
        Result<List<PostResponse>> GetAll();
        Result<PostResponse> GetById(int postId);
        Result<List<PostResponse>> GetMyPosts(int userId);
    }
}
