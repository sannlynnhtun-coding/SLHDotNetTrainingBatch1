using SLHDotNetTrainingBatch1.WebApi.Models;

namespace SLHDotNetTrainingBatch1.WebApi.Services
{
    public interface IProductService
    {
        ResponseModel CreateProduct(ProductModel requestModel);
        ResponseModel GetProductById(int id);
        ResponseModel GetProducts();
        ResponseModel GetProducts(int pageNo, int pageSize);
        ResponseModel UpdateProduct(int productId, ProductModel requestModel);
    }
}