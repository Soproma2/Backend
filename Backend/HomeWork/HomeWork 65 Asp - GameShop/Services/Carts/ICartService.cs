using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Responses;

namespace HomeWork_65_Asp___GameShop.Services.Carts
{
    public interface ICartService
    {
        Result<CartResponse> GetMyCart(int userId);
        Result<CartResponse> AddItem(int gameId, int userId);
        Result<CartResponse> RemoveItem(int gameId, int userId);
        Result<CartResponse> Clear(int userId);
    }
}
