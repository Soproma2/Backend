using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Post;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;

namespace HomeWork_57___Asp_E_Commerce.Services.Carts
{
    public class CartsService : ICartsService
    {
        public Result<string> AddToCart(User user, AddToCartRequest req)
        {
            throw new NotImplementedException();
        }

        public Result<string> ClearCart(User user)
        {
            throw new NotImplementedException();
        }

        public Result<string> RemoveFromCart(User user)
        {
            throw new NotImplementedException();
        }

        public Result<string> UpdateCartQuantity(User user, UpdateCartQuantityrequest req)
        {
            throw new NotImplementedException();
        }

        public Result<CartsResponse> ViewCart(User user)
        {
            throw new NotImplementedException();
        }
    }
}
