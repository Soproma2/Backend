using HomeWork_45___Asp.Data;
using HomeWork_45___Asp.DTOs.Requests;
using HomeWork_45___Asp.DTOs.Responses;

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
            throw new NotImplementedException();
        }

        public ProductResponse DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ProductResponse GetProduct()
        {
            throw new NotImplementedException();
        }

        public ProductResponse UpdateProduct(int Id, UpdateProductDto req)
        {
            throw new NotImplementedException();
        }
    }
}
