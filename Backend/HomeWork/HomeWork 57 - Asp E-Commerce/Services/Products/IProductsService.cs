using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Post;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;

namespace HomeWork_57___Asp_E_Commerce.Services.Products
{
    public interface IProductsService
    {
        Result<List<Product>> ViewAllProducts();
        Result<List<Product>> SearchProducts();
        Result<List<Product>> FilterByCategory();
        Result<Product> ViewProductDetails();
        Result<string> AddProduct(CreateProductRequest req);
        Result<string> UpdateProduct(UpdateProductRequest req);
        Result<string> DeleteProduct();
        Result<List<CategoryResponse>> ViewCategories();
    }
}
