using HomeWork_48___Asp.Common;
using HomeWork_48___Asp.DTOs.Requests;
using HomeWork_48___Asp.DTOs.Responses;

namespace HomeWork_48___Asp.Services.Cars
{
    public interface ICarsService
    {
        ApiResponse<List<CarResponse>>? GetCars();
        ApiResponse<CarResponse> AddCar(CarCreateReq req);
        ApiResponse<CarResponse>? UpdateCar(int Id, CarUpdateReq req);
        ApiResponse<CarResponse>? DeleteCar(int Id);
        ApiResponse<CarResponse>? GetCarById(int Id);
        ApiResponse<List<CarResponse>>? SortCarByPrice();
    }
}
