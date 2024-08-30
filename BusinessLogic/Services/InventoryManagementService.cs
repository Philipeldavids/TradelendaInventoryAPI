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

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var res = await _inventoryManagementRepository.GetallProducts();

            return new ServiceResponse<List<Product>>()
            {
                Data = res,
                Success = true,
                Message = "LIst of Products SUcccefull"
            };
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByID(String Id)
        {
            var res = await _inventoryManagementRepository.GetProductbyId(Id);
            return new ServiceResponse<List<Product>>()
            {
                Data = res,
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
