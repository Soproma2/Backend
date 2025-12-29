using System.Collections.Generic;
using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.DTOs.Responses;

namespace Homework_47___Asp.Services.Product
{
    public interface IProductService
    {
        List<ProductResponse>? GetProducts();
        ProductResponse? GetProductById(int id);
        List<ProductResponse>? GetProductByCategory(string name);
        ProductResponse AddProduct(CreateRequest req);
    }
}
