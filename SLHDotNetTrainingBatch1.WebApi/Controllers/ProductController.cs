using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.Shared;
using SLHDotNetTrainingBatch1.WebApi.Models;

namespace SLHDotNetTrainingBatch1.WebApi.Controllers
{
    // https://localhost:3000/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public ProductController()
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetTrainingBatch1",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            _dapperService = new DapperService(_sqlConnectionStringBuilder);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var lst = _dapperService.Query<ProductModel>("select * from tbl_product");
            var data = new
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst,
            };
            return Ok(data);
        }

        [HttpGet("Edit/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            string query = "select * from tbl_product where ProductId=@ProductId";
            var lst = _dapperService.Query<ProductModel>(query, new
            {
                ProductId = id
            });
            if (lst.Count == 0)
            {
                return NotFound(new
                {
                    IsSuccess = false,
                    Message = "Product not found."
                });
            }
            var data = new
            {
                IsSuccess = true,
                Message = "Success.",
                Data = lst[0],
            };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            product.CreatedDateTime = DateTime.Now;
            product.CreatedBy = 1;
            string query = @"
                insert into tbl_product(
                    ProductName, 
                    ProductCategoryId, 
                    Price, 
                    Quantity, 
                    CreatedDateTime, 
                    CreatedBy)
                values(
                    @ProductName, 
                    @ProductCategoryId, 
                    @Price, 
                    @Quantity, 
                    @CreatedDateTime, 
                    @CreatedBy)";
            int result =_dapperService.Execute(query, product);
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success." : "Fail.",
            };
            return Ok(data);
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProduct()
        {
            return Ok("CreateOrUpdateProduct");
        }

        [HttpPatch]
        public IActionResult UpdateProduct()
        {
            return Ok("UpdateProduct");
        }

        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return Ok("DeleteProduct");
        }
    }
}
