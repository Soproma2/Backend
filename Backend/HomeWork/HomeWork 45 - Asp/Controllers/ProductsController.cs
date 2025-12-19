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


    }
}
