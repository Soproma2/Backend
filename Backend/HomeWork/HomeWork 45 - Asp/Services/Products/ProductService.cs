using Azure;
using HomeWork_45___Asp.Data;
using HomeWork_45___Asp.DTOs.Requests;
using HomeWork_45___Asp.DTOs.Responses;
using HomeWork_45___Asp.Models;

namespace HomeWork_45___Asp.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly DataContext _db;
        public ProductService(DataContext db)
        {
            _db = db;
        }

        public ProductResponse CreateProduct(CreateProductDto req)
        {
            Models.Product product = new Models.Product()
            {
                Name = req.Name,
                Description = req.Description,
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
                Price = product.Price,
            };
        }

        public ProductResponse? DeleteProduct(int id)
        {
            var prod = _db.Products.Find(id);

            if (prod == null) return null;

            _db.Products.Remove(prod);
            _db.SaveChanges();
            return new ProductResponse()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
            };
        }

        public List<ProductResponse>? GetProduct()
        {
            var response = _db.Products
                .Select(e => new ProductResponse()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Price = e.Price,
                }).ToList();
            return response;
        }

        public ProductResponse? UpdateProduct(int Id, UpdateProductDto req)
        {
            var product = _db.Products.Find(Id);

            if (product == null) return null;

            if (!string.IsNullOrWhiteSpace(req.Name))
                product.Name = req.Name;

            if (!string.IsNullOrWhiteSpace(req.Description))
                product.Description = req.Description;

            if (req.Price.HasValue)
                product.Price = req.Price.Value;

            if (req.Stock.HasValue)
                product.Stock = req.Stock.Value;

            _db.SaveChanges();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
