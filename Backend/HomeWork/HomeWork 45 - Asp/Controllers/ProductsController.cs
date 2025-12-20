using HomeWork_45___Asp.DTOs.Requests;
using HomeWork_45___Asp.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_45___Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _bs;
        public ProductsController(IProductService bs) => _bs = bs;

        [HttpPost]
        public IActionResult Create(CreateProductDto req)
        {
            var result = _bs.CreateProduct(req);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _bs.GetProduct();
            return Ok(result);
        }

        [HttpPut("Product/{id}")]
        public IActionResult Update(int id, UpdateProductDto req)
        {
            var result = _bs.UpdateProduct(id, req);
            return Ok(result);
        }

        [HttpDelete("product/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bs.DeleteProduct(id);
            return Ok(result);
        }
    }
}
