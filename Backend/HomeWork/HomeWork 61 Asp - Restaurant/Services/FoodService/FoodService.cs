using HomeWork_61_Asp___Restaurant.Common;
using HomeWork_61_Asp___Restaurant.Data;
using HomeWork_61_Asp___Restaurant.DTOs.Requests;
using HomeWork_61_Asp___Restaurant.DTOs.Responses;
using HomeWork_61_Asp___Restaurant.Models;

namespace HomeWork_61_Asp___Restaurant.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly AppDbContext _context;

        public FoodService(AppDbContext context)
        {
            _context = context;
        }

        public Result<FoodResponse> Create(CreateFoodReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return Result<FoodResponse>.BadRequest("Name is required");

            if (string.IsNullOrWhiteSpace(req.Category))
                return Result<FoodResponse>.BadRequest("Category is required");

            if (req.Price <= 0)
                return Result<FoodResponse>.BadRequest("Price must be greater than 0");

            if (_context.Foods.Any(f => f.Name == req.Name))
                return Result<FoodResponse>.BadRequest("Food item already exists");

            var food = new Food
            {
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                Category = req.Category,
                IsAvailable = true
            };

            _context.Foods.Add(food);
            _context.SaveChanges();

            return Result<FoodResponse>.success("Food created successfully", ToResponse(food));
        }

        public Result<FoodResponse> Update(int id, UpdateFoodReq req)
        {
            if (id <= 0)
                return Result<FoodResponse>.BadRequest("Invalid ID");

            var food = _context.Foods.Find(id);
            if (food == null)
                return Result<FoodResponse>.NotFound("Food not found");

            if (req.Price.HasValue && req.Price <= 0)
                return Result<FoodResponse>.BadRequest("Price must be greater than 0");

            food.Name = req.Name ?? food.Name;
            food.Description = req.Description ?? food.Description;
            food.Price = req.Price ?? food.Price;
            food.Category = req.Category ?? food.Category;
            food.IsAvailable = req.IsAvailable ?? food.IsAvailable;

            _context.SaveChanges();
            return Result<FoodResponse>.success("Food updated successfully", ToResponse(food));
        }

        public Result<FoodResponse> Delete(int id)
        {
            if (id <= 0)
                return Result<FoodResponse>.BadRequest("Invalid ID");

            var food = _context.Foods.Find(id);
            if (food == null)
                return Result<FoodResponse>.NotFound("Food not found");

            _context.Foods.Remove(food);
            _context.SaveChanges();
            return Result<FoodResponse>.success("Food deleted successfully", ToResponse(food));
        }

        public Result<List<FoodResponse>> GetAll()
        {
            var foods = _context.Foods.Select(f => new FoodResponse
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                Price = f.Price,
                Category = f.Category,
                IsAvailable = f.IsAvailable
            }).ToList();

            if (!foods.Any())
                return Result<List<FoodResponse>>.NotFound("No food items found");

            return Result<List<FoodResponse>>.success(null, foods);
        }

        public Result<FoodResponse> GetById(int id)
        {
            if (id <= 0)
                return Result<FoodResponse>.BadRequest("Invalid ID");

            var food = _context.Foods.Find(id);
            if (food == null)
                return Result<FoodResponse>.NotFound("Food not found");

            return Result<FoodResponse>.success(null, ToResponse(food));
        }

        public Result<List<FoodResponse>> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return Result<List<FoodResponse>>.BadRequest("Category is required");

            var foods = _context.Foods
                .Where(f => f.Category.ToLower() == category.ToLower())
                .Select(f => new FoodResponse
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    Price = f.Price,
                    Category = f.Category,
                    IsAvailable = f.IsAvailable
                }).ToList();

            if (!foods.Any())
                return Result<List<FoodResponse>>.NotFound("No food items found in this category");

            return Result<List<FoodResponse>>.success(null, foods);
        }

        private static FoodResponse ToResponse(Food food) => new FoodResponse
        {
            Id = food.Id,
            Name = food.Name,
            Description = food.Description,
            Price = food.Price,
            Category = food.Category,
            IsAvailable = food.IsAvailable
        };
    }
}
