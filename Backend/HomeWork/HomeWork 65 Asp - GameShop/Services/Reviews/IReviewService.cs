using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;

namespace HomeWork_65_Asp___GameShop.Services.Reviews
{
    public interface IReviewService
    {
        Result<ReviewResponse> Create(int gameId, CreateReviewReq req, int userId);
        Result<ReviewResponse> Delete(int reviewId, int userId);
        Result<List<ReviewResponse>> GetByGame(int gameId);
    }
}
