using Homework_47___Asp.Data;
using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.DTOs.Responses;
using Homework_47___Asp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Homework_47___Asp.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly DataContext _db;

        public ProductService(DataContext db)
        {
            _db = db;
        }

        public List<ProductResponse>? GetProducts()
        {
            var res = _db.Products
                .Select(e => new ProductResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category,
                    Price = e.Price,
                    Stock = e.Stock
                })
                .ToList();
            if (res == null) return null;
            return res;
        }

        public ProductResponse? GetProductById(int id)
        {
            var e = _db.Products.Find(id);
            if (e == null) return null!;

            return new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Category = e.Category,
                Price = e.Price,
                Stock = e.Stock
            };
        }

        public List<ProductResponse>? GetProductByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new();

            var normalized = category.Trim().ToLower();

            return _db.Products.Where(p => p.Category != null && p.Category.Trim().ToLower() == normalized)
                .Select(e => new ProductResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category,
                    Price = e.Price,
                    Stock = e.Stock
                })
                .ToList();
        }


        public ProductResponse AddProduct(CreateRequest req)
        {
            Models.Product product = new Models.Product()
            {
                Name = req.Name,
                Description = req.Description,
                Category = req.Category,
                Price = req.Price,
                Stock = req.Stock
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public ProductResponse Discount(int id, int percentage)
        {
            var product = _db.Products.Find(id);

            if (product == null) return null;
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Invalid discount percentage");

            product.Price = product.Price - (product.Price * percentage / 100);

            _db.SaveChanges();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public ProductResponse AddStock(int id, int quantity)
        {
            var product = _db.Products.Find(id);
            if (product == null) return null;

            if (quantity < 0 || quantity > 100) throw new ArgumentException("Invalid quantity");

            product.Stock += quantity;

            _db.SaveChanges();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
