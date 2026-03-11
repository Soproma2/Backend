using HomeWork_60___ASP_Cars.Common;
using HomeWork_60___ASP_Cars.Data;
using HomeWork_60___ASP_Cars.DTOs.Responses;
using HomeWork_60___ASP_Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_60___ASP_Cars.Services.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        public Result<PurchaseResponse> Buy(int carId, int buyerId)
        {
            if (carId <= 0)
                return Result<PurchaseResponse>.BadRequest("Invalid car ID");

            var car = _context.Cars.Include(c => c.Seller).FirstOrDefault(c => c.Id == carId);
            if (car == null)
                return Result<PurchaseResponse>.NotFound("Car not found");

            if (car.IsSold)
                return Result<PurchaseResponse>.BadRequest("Car is already sold");

            if (car.SellerId == buyerId)
                return Result<PurchaseResponse>.BadRequest("You cannot buy your own car");

            car.IsSold = true;

            var purchase = new Purchase
            {
                CarId = carId,
                BuyerId = buyerId,
                PurchasedAt = DateTime.Now
            };

            _context.Purchases.Add(purchase);
            _context.SaveChanges();

            return Result<PurchaseResponse>.success("Car purchased successfully", ToResponse(purchase, car));
        }

        public Result<List<PurchaseResponse>> GetMyPurchases(int buyerId)
        {
            var purchases = _context.Purchases
                .Include(p => p.Car).ThenInclude(c => c.Seller)
                .Where(p => p.BuyerId == buyerId)
                .Select(p => new PurchaseResponse
                {
                    Id = p.Id,
                    CarId = p.CarId,
                    CarBrand = p.Car.Brand,
                    CarModel = p.Car.Model,
                    Price = p.Car.Price,
                    SellerName = p.Car.Seller.FullName,
                    PurchasedAt = p.PurchasedAt
                }).ToList();

            if (!purchases.Any())
                return Result<List<PurchaseResponse>>.NotFound("No purchases found");

            return Result<List<PurchaseResponse>>.success(null, purchases);
        }

        private static PurchaseResponse ToResponse(Purchase purchase, Car car) => new PurchaseResponse
        {
            Id = purchase.Id,
            CarId = car.Id,
            CarBrand = car.Brand,
            CarModel = car.Model,
            Price = car.Price,
            SellerName = car.Seller?.FullName,
            PurchasedAt = purchase.PurchasedAt
        };
    }
}
