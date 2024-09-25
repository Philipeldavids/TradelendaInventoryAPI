using BusinessLogic.Interfaces;
using BusinessLogic.Utilities.Pagination;
using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class InventoryManagementService : IInventoryManagementService
    {
        private readonly IInventoryManagementRepository _inventoryManagementRepository;
        private readonly INotificationService _notification;
        private readonly IPeoplesRepository _peoplerepo;
        private readonly IUserService _userService;
        public InventoryManagementService(IInventoryManagementRepository inventoryManagementRepository, 
            INotificationService notification, IPeoplesRepository peoplerepo, IUserService userService)         
        {
            _inventoryManagementRepository = inventoryManagementRepository;
            _notification = notification;
            _peoplerepo = peoplerepo;
            _userService = userService; 
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
            var warehouseEmail = _peoplerepo.GetWarehouse().Result.Data.Where(x => x.WarehouseId == product.Warehouse).Select(x=>x.supplier.Email).FirstOrDefault();

            await _notification.SendNotificationAsync(
                   product,
                   warehouseEmail,
                   "New Products Added",
                   user => $"New Products Added for: {warehouseEmail}"
                   );

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
