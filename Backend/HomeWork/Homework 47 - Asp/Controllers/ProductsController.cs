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

        [HttpGet("product/{Id}")]
        public IActionResult GetProductById(int Id)
        {
            var product = _productService.GetProductById(Id);
            return Ok(product);
        }

        [HttpGet("product/{Category}")]
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
    }
}
