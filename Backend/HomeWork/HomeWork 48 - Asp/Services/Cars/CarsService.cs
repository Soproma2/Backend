using HomeWork_48___Asp.Common;
using HomeWork_48___Asp.Data;
using HomeWork_48___Asp.DTOs.Requests;
using HomeWork_48___Asp.DTOs.Responses;
using HomeWork_48___Asp.Models;

namespace HomeWork_48___Asp.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly DataContext _db;
        public CarsService(DataContext db)
        {
            _db = db;
        }
        public ApiResponse<CarResponse> AddCar(CarCreateReq req)
        {
            Car car = new Car()
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price
            };

            _db.Cars.Add(car);
            _db.SaveChanges();

            return new ApiResponse<CarResponse>
            {
                Status = StatusCodes.Status200OK,
                Value = new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Price = car.Price
                },
                Message = "Car added successfully"
            };
        }

        public ApiResponse<CarResponse>? DeleteCar(int Id)
        {
            var car = _db.Cars.Find(Id);
            if (car == null) return null;
            _db.Cars.Remove(car);
            _db.SaveChanges();

            return new ApiResponse<CarResponse>
            {
                Status = StatusCodes.Status200OK,
                Value = new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Price = car.Price
                },
                Message = "Car deleted successfully"
            };
        }

        public ApiResponse<CarResponse>? GetCarById(int Id)
        {
            var car = _db.Cars.Find(Id);
            if (car == null) return null;

            return new ApiResponse<CarResponse>
            {
                Status = StatusCodes.Status200OK,
                Value = new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Price = car.Price
                },
            };
        }

        public ApiResponse<List<CarResponse>>? GetCars()
        {
            var cars = _db.Cars.Select(e => new CarResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price
            }).ToList();

            return new ApiResponse<List<CarResponse>>
            {
                Status = StatusCodes.Status200OK,
                Value = cars
            };
        }

        public ApiResponse<List<CarResponse>>? SortCarByPrice()
        {
            var cars = _db.Cars
                .OrderBy(c => c.Price)
                .Select(e => new CarResponse()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Price = e.Price
                }).ToList();
            return new ApiResponse<List<CarResponse>>()
            {
                Status = StatusCodes.Status200OK,
                Value = cars
            };
        }

        public ApiResponse<CarResponse>? UpdateCar(int Id, CarUpdateReq req)
        {
            var car = _db.Cars.Find(Id);
            if (car == null) return null;

            if(!string.IsNullOrWhiteSpace(req.Name)) car.Name = req.Name;
            if(!string.IsNullOrWhiteSpace(req.Description)) car.Description = req.Description;
            if (car.Price != null) car.Price = req.Price.Value;

            _db.SaveChanges();

            return new ApiResponse<CarResponse>
            {
                Status = StatusCodes.Status200OK,
                Value = new CarResponse
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Price = car.Price
                },
                Message = "Car Updated successfully"
            };
        }
    }
}
