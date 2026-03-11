using HomeWork_60___ASP_Cars.Common;
using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.DTOs.Responses;

namespace HomeWork_60___ASP_Cars.Services.CarService
{
    public interface ICarService
    {
        Result<CarResponse> Create(CreateCarReq req, int sellerId);
        Result<CarResponse> Update(int id, UpdateCarReq req, int sellerId);
        Result<CarResponse> Delete(int id, int sellerId);
        Result<List<CarResponse>> GetAll();
        Result<CarResponse> GetById(int id);
        Result<List<CarResponse>> Search(string query);
        Result<List<CarResponse>> Filter(string? brand, int? year, decimal? minPrice, decimal? maxPrice, string? fuelType);
        Result<List<CarResponse>> GetMyCars(int sellerId);
    }
}
