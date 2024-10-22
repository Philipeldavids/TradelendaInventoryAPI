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

        public async Task<ServiceResponse<bool>> AddProducts(ProductModel product)
        {
            var category = await _inventoryManagementRepository.GetCategoryById(product.Category);
            var brand = await _inventoryManagementRepository.GetBrandById(product.Brand);
            Product product2 = new Product();

            product2.Store = product.Store;
            product2.ProductImageUrl = product.ProductImageUrl;
            product2.IsExpired = false;
            product2.SKU = product.SKU;
            product2.Quantity = product.Quantity;
            product2.ProductImageUrl = product.ProductImageUrl;
            product2.ProductName = product.ProductName;
            product2.ProductDescription = product.ProductDescription;
            product2.ExpiredDate = product.ExpiredDate.ToUniversalTime();
            product2.Price = product.Price;
            product2.Category = category;
            product2.Category.CategorySLug = category.CategoryName;
            product2.Brand = brand;            
            product2.Warehouse = product.Warehouse;
            product2.UnitCost = product.UnitCost;
            product2.ManufacturedDate = product.ManufacturedDate.ToUniversalTime();
            product2.Barcode = product.Barcode;
            product2.CreatedAt = DateTime.UtcNow;
            product2.CreatedBy = "ShopOwner";
            product2.Unit = product.Unit;
            
            var res = await _inventoryManagementRepository.AddProducts(product2);
            //var warehouseEmail = _peoplerepo.GetWarehouse().Result.Where(x => x.WarehouseId == product.Warehouse).Select(x=>x.supplier.Email).FirstOrDefault();

            //await _notification.SendNotificationAsync(
            //       product,
            //       warehouseEmail,
            //       "New Products Added",
            //       user => $"New Products Added for: {warehouseEmail}"
            //       );

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
