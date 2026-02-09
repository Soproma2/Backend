using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;
namespace HomeWork_57___Asp_E_Commerce.Services.Users
{
    public interface IUsersService
    {
        Result<ProfileResponse> ViewProfile(User user);
        Result<string> AddBalance(User user, UpdateBalanceRequest req);
        Result<string> UpdateProfile(User user, UpdateProfileRequest req);
    }
}
