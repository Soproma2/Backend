using HomeWork_53___Social_System.Common;

namespace HomeWork_53___Social_System.Services.LikeServices
{
    public interface ILikeService
    {
        Result<string> Toggle(int postId, int userId);
    }
}
