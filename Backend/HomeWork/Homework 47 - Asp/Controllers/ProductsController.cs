using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_47___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService products)
        {
            _productService = products;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("product/{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("product/{category}")]
        public IActionResult GetProductByCategory(string category)
        {
            var products = _productService.GetProductByCategory(category);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(CreateRequest req)
        {
            var product = _productService.AddProduct(req);
            return Ok(product);
        }

        [HttpPost("product/{id}/dicount")]
        public IActionResult Discount(int id, int percentage)
        {
            var discount = _productService.Discount(id,percentage);
            return Ok(discount);
        }

        [HttpPost("product/{id}/addstock")]
        public IActionResult AddStock(int id, int quantity)
        {
            var stock = _productService.AddStock(id,quantity);
            return Ok(stock);
        }

    }
}
