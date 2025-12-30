using System.Collections.Generic;
using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.DTOs.Responses;

namespace Homework_47___Asp.Services.Product
{
    public interface IProductService
    {
        List<ProductResponse>? GetProducts();
        ProductResponse? GetProductById(int id);
        List<ProductResponse>? GetProductByCategory(string category);
        List<ProductResponse>? GetFilterByPrice();
        ProductResponse AddProduct(CreateRequest req);
        ProductResponse Discount(int id, int percentage);
        ProductResponse AddStock(int  id, int quantity);
    }
}
