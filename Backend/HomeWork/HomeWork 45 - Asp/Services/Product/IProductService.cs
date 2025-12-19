using HomeWork_45___Asp.DTOs.Requests;
using HomeWork_45___Asp.DTOs.Responses;

namespace HomeWork_45___Asp.Services.Product
{
    public interface IProductService
    {
        ProductResponse CreateProduct(CreateProductDto req);
        ProductResponse UpdateProduct(int Id, UpdateProductDto req);
        ProductResponse DeleteProduct(int id);
        ProductResponse GetProduct();
    }
}
