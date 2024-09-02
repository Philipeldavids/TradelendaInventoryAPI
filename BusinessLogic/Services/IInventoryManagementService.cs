using BusinessLogic.Utilities.Pagination;
using Infracstructure;
using Infracstructure.Models;

namespace BusinessLogic.Services
{
    public interface IInventoryManagementService
    {
        Task<ServiceResponse<PaginationModel<IEnumerable<Product>>>> GetProducts(int pageSize, int pageNumber);
        Task<ServiceResponse<PaginationModel<IEnumerable<Product>>>> GetProductByID(string Id, int pageSize, int pageNumber);
        Task<ServiceResponse<bool>> EditProduct(Product product, string Id);
        Task<ServiceResponse<bool>> AddProducts(Product product);
        Task<ServiceResponse<bool>> DeleteProduct(string id);
    }
}