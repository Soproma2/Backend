using HomeWork_61_Asp___Restaurant.Common;
using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.DTOs.Responses;

namespace HomeWork_61_Asp___Restaurant.Services.FoodService
{
    public interface IFoodService
    {
        Result<FoodResponse> Create(CreateFoodReq req);
        Result<FoodResponse> Update(int id, UpdateFoodReq req);
        Result<FoodResponse> Delete(int id);
        Result<List<FoodResponse>> GetAll();
        Result<FoodResponse> GetById(int id);
        Result<List<FoodResponse>> GetByCategory(string category);
    }
}
