using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;
using HomeWork_65_Asp___GameShop.DTOs.Responses;

namespace HomeWork_65_Asp___GameShop.Services.Games
{
    public interface IGamesService
    {
        Result<GameResponse> Create(CreateGameReq req, int sellerId);
        Result<GameResponse> Update(int id, UpdateGameReq req, int sellerId);
        Result<GameResponse> Delete(int id, int sellerId);
        Result<List<GameResponse>> GetAll();
        Result<GameResponse> GetById(int id);
        Result<List<GameResponse>> GetMyGames(int sellerId);
        Result<List<GameResponse>> Search(string query);
        Result<List<GameResponse>> Filter(string? genre, string? platform, decimal? minPrice, decimal? maxPrice);
    }
}

