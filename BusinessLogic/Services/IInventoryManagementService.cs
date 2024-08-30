using Infracstructure;
using Infracstructure.Models;

namespace BusinessLogic.Services
{
    public interface IInventoryManagementService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<List<Product>>> GetProductByID(String Id);
        Task<ServiceResponse<bool>> EditProduct(Product product, string Id);
        Task<ServiceResponse<bool>> AddProducts(Product product);
        Task<ServiceResponse<bool>> DeleteProduct(string id);
    }
}