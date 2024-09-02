using BusinessLogic.Utilities.Pagination;
using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class InventoryManagementService : IInventoryManagementService
    {
        private readonly IInventoryManagementRepository _inventoryManagementRepository;
        public InventoryManagementService(IInventoryManagementRepository inventoryManagementRepository)         
        {
            _inventoryManagementRepository = inventoryManagementRepository;
        }

        public async Task<ServiceResponse<PaginationModel<IEnumerable<Product>>>> GetProducts(int pageSize, int pageNumber)
        {
            var res = await _inventoryManagementRepository.GetallProducts();

            var result = PaginationClass.PaginationAsync(res, pageSize, pageNumber);
            return new ServiceResponse<PaginationModel<IEnumerable<Product>>>()
            {
                Data = result,
                Success = true,
                Message = "LIst of Products SUcccefull"
            };
        }

        public async Task<ServiceResponse<PaginationModel<IEnumerable<Product>>>> GetProductByID(string Id, int pageSize, int pageNumber)
        {
            var res = await _inventoryManagementRepository.GetProductbyId(Id);
            var result = PaginationClass.PaginationAsync(res, pageSize, pageNumber);
            return new ServiceResponse<PaginationModel<IEnumerable<Product>>>()
            {
                Data = result,
                Success = true,
                Message = "List of specific products successful"
            };
        }

        public async Task<ServiceResponse<bool>> EditProduct(Product product, string Id)
        {
            var res = await _inventoryManagementRepository.EditProduct(product, Id);

            return new ServiceResponse<bool>()
            {
                Data = res,
                Success = true,
                Message = "Product edited successfully"

            };
        }

        public async Task<ServiceResponse<bool>> AddProducts(Product product)
        {
            var res = await _inventoryManagementRepository.AddProducts(product);
            return new ServiceResponse<bool>()
            {
                Data = res,
                Success = true,
                Message = "Product added successfully"
            };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(string id)
        {
            var res = await _inventoryManagementRepository.DeleteProduct(id);

            return new ServiceResponse<bool>()
            {
                Data = res,
                Success = true,
                Message = "Product deleted succesfully"
            };
        }
    }
}
