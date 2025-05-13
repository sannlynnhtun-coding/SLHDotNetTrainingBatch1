using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.Shared;
using SLHDotNetTrainingBatch1.WebApi.Models;
using SLHDotNetTrainingBatch1.WebApi.Services;

namespace SLHDotNetTrainingBatch1.WebApi.Controllers
{
    // https://localhost:3000/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _productService.GetProducts();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetProducts(int pageNo, int pageSize)
        {
            var model = _productService.GetProducts(pageNo, pageSize);
            return Ok(model);
        }

        [HttpGet("Edit/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var model = _productService.GetProductById(id);
            if (!model.IsSuccess)
            {
                return NotFound(model);
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            Console.WriteLine("CreateProduct => " + product.ToJson());
            var model = _productService.CreateProduct(product);
            return Ok(_productService.CreateProduct(product));
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProduct()
        {
            return Ok("CreateOrUpdateProduct");
        }

        [HttpPatch("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductModel product)
        {
            var model = _productService.UpdateProduct(productId, product);
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return Ok("DeleteProduct");
        }
    }
}
