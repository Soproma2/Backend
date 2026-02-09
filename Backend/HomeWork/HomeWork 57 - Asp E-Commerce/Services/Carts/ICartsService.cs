using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Post;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;

namespace HomeWork_57___Asp_E_Commerce.Services.Carts
{
    public interface ICartsService
    {
        Result<string> AddToCart(User user, AddToCartRequest req);
        Result<string> RemoveFromCart(User user);
        Result<CartsResponse> ViewCart(User user);
        Result<string> UpdateCartQuantity(User user, UpdateCartQuantityrequest req);
        Result<string> ClearCart(User user);
    }
}
