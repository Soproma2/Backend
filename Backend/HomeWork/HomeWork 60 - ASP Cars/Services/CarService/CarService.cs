using HomeWork_60___ASP_Cars.Common;
using HomeWork_60___ASP_Cars.Data;
using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.DTOs.Responses;
using HomeWork_60___ASP_Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_60___ASP_Cars.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public Result<CarResponse> Create(CreateCarReq req, int sellerId)
        {
            if (string.IsNullOrWhiteSpace(req.Brand))
                return Result<CarResponse>.BadRequest("Brand is required");

            if (string.IsNullOrWhiteSpace(req.Model))
                return Result<CarResponse>.BadRequest("Model is required");

            if (req.Year == default || req.Year > DateTime.Now.Year)
                return Result<CarResponse>.BadRequest("Invalid year");

            if (req.Price <= 0)
                return Result<CarResponse>.BadRequest("Price must be greater than 0");

            if (req.Mileage < 0)
                return Result<CarResponse>.BadRequest("Mileage cannot be negative");

            var car = new Car
            {
                Brand = req.Brand,
                Model = req.Model,
                Year = req.Year,
                Price = req.Price,
                FuelType = req.FuelType,
                Mileage = req.Mileage,
                SellerId = sellerId
            };

            _context.Cars.Add(car);
            _context.SaveChanges();

            return Result<CarResponse>.success("Car listed successfully", ToResponse(car));
        }

        public Result<CarResponse> Update(int id, UpdateCarReq req, int sellerId)
        {
            if (id <= 0)
                return Result<CarResponse>.BadRequest("Invalid ID");

            var car = _context.Cars.Find(id);
            if (car == null)
                return Result<CarResponse>.NotFound("Car not found");

            if (car.SellerId != sellerId)
                return Result<CarResponse>.BadRequest("You can only edit your own listings");

            if (string.IsNullOrWhiteSpace(req.Brand))
                return Result<CarResponse>.BadRequest("Brand is required");

            if (string.IsNullOrWhiteSpace(req.Model))
                return Result<CarResponse>.BadRequest("Model is required");

            if (req.Year < 1886 || req.Year > DateTime.Now.Year)
                return Result<CarResponse>.BadRequest("Invalid year");

            if (req.Price <= 0)
                return Result<CarResponse>.BadRequest("Price must be greater than 0");

            if (req.Mileage < 0)
                return Result<CarResponse>.BadRequest("Mileage cannot be negative");

            car.Brand = req.Brand;
            car.Model = req.Model;
            car.Year = req.Year.Value;
            car.Price = req.Price.Value ;
            car.FuelType = req.FuelType;
            car.Mileage = req.Mileage.Value;

            _context.SaveChanges();
            return Result<CarResponse>.success("Car updated successfully", ToResponse(car));
        }

        public Result<CarResponse> Delete(int id, int sellerId)
        {
            if (id <= 0)
                return Result<CarResponse>.BadRequest("Invalid ID");

            var car = _context.Cars.Find(id);
            if (car == null)
                return Result<CarResponse>.NotFound("Car not found");

            if (car.SellerId != sellerId)
                return Result<CarResponse>.BadRequest("You can only delete your own listings");

            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Result<CarResponse>.success("Car deleted successfully", ToResponse(car));
        }

        public Result<List<CarResponse>> GetAll()
        {
            var cars = _context.Cars
                .Include(c => c.Seller)
                .Where(c => !c.IsSold)
                .Select(c => new CarResponse
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    FuelType = c.FuelType,
                    Mileage = c.Mileage,
                    IsSold = c.IsSold,
                    SellerName = c.Seller.FullName
                }).ToList();

            if (!cars.Any())
                return Result<List<CarResponse>>.NotFound("No cars found");

            return Result<List<CarResponse>>.success(null, cars);
        }

        public Result<CarResponse> GetById(int id)
        {
            if (id <= 0)
                return Result<CarResponse>.BadRequest("Invalid ID");

            var car = _context.Cars.Include(c => c.Seller).FirstOrDefault(c => c.Id == id);
            if (car == null)
                return Result<CarResponse>.NotFound("Car not found");

            return Result<CarResponse>.success(null, ToResponse(car));
        }

        public Result<List<CarResponse>> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Result<List<CarResponse>>.BadRequest("Search term is required");

            var cars = _context.Cars
                .Include(c => c.Seller)
                .Where(c => !c.IsSold && (c.Brand.Contains(query) || c.Model.Contains(query)))
                .Select(c => new CarResponse
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    FuelType = c.FuelType,
                    Mileage = c.Mileage,
                    IsSold = c.IsSold,
                    SellerName = c.Seller.FullName
                }).ToList();

            if (!cars.Any())
                return Result<List<CarResponse>>.NotFound("No cars found");

            return Result<List<CarResponse>>.success(null, cars);
        }

        public Result<List<CarResponse>> Filter(string? brand, int? year, decimal? minPrice, decimal? maxPrice, string? fuelType)
        {
            var query = _context.Cars.Include(c => c.Seller).Where(c => !c.IsSold);

            if (!string.IsNullOrWhiteSpace(brand))
                query = query.Where(c => c.Brand == brand);

            if (year.HasValue)
                query = query.Where(c => c.Year == year);

            if (minPrice.HasValue)
                query = query.Where(c => c.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(c => c.Price <= maxPrice);

            if (!string.IsNullOrWhiteSpace(fuelType))
                query = query.Where(c => c.FuelType == fuelType);

            var cars = query.Select(c => new CarResponse
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                Year = c.Year,
                Price = c.Price,
                FuelType = c.FuelType,
                Mileage = c.Mileage,
                IsSold = c.IsSold,
                SellerName = c.Seller.FullName
            }).ToList();

            if (!cars.Any())
                return Result<List<CarResponse>>.NotFound("No cars found");

            return Result<List<CarResponse>>.success(null, cars);
        }

        public Result<List<CarResponse>> GetMyCars(int sellerId)
        {
            var cars = _context.Cars
                .Include(c => c.Seller)
                .Where(c => c.SellerId == sellerId)
                .Select(c => new CarResponse
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    FuelType = c.FuelType,
                    Mileage = c.Mileage,
                    IsSold = c.IsSold,
                    SellerName = c.Seller.FullName
                }).ToList();

            if (!cars.Any())
                return Result<List<CarResponse>>.NotFound("You have no listings");

            return Result<List<CarResponse>>.success(null, cars);
        }

        private static CarResponse ToResponse(Car car) => new CarResponse
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            Price = car.Price,
            FuelType = car.FuelType,
            Mileage = car.Mileage,
            IsSold = car.IsSold,
            SellerName = car.Seller?.FullName
        };
    }
}
