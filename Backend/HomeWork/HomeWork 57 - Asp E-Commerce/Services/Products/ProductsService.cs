using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Post;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;
using HomeWork_57___Asp_E_Commerce.DTOs.Responses;
using HomeWork_57___Asp_E_Commerce.Models;

namespace HomeWork_57___Asp_E_Commerce.Services.Products
{
    public class ProductsService : IProductsService
    {
        public Result<string> AddProduct(CreateProductRequest req)
        {
            throw new NotImplementedException();
        }

        public Result<string> DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public Result<List<Product>> FilterByCategory()
        {
            throw new NotImplementedException();
        }

        public Result<List<Product>> SearchProducts()
        {
            throw new NotImplementedException();
        }

        public Result<string> UpdateProduct(UpdateProductRequest req)
        {
            throw new NotImplementedException();
        }

        public Result<List<Product>> ViewAllProducts()
        {
            throw new NotImplementedException();
        }

        public Result<List<CategoryResponse>> ViewCategories()
        {
            throw new NotImplementedException();
        }

        public Result<Product> ViewProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
