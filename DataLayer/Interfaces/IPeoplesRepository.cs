using Infracstructure.Models;
using Infracstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IPeoplesRepository
    {
        Task<Store> GetStoreByCode(int code);
        Task<ServiceResponse<List<Store>>> GetStore();
        Task<ServiceResponse<bool>> AddStore(Store store);
        Task<ServiceResponse<bool>> EditStore(Store store, string Id);
        Task<ServiceResponse<bool>> DeleteStores(string ID);

        Task<ServiceResponse<List<Customer>>> GetCustomers();
        Task<ServiceResponse<bool>> AddCustomer(Customer customer);
        Task<ServiceResponse<bool>> EditCustomer(Customer customer, string Id);
        Task<ServiceResponse<bool>> DeleteCustomer(string Id);
        Task<ServiceResponse<List<Supplier>>> GetSupplier();
        Task<ServiceResponse<bool>> AddSupplier(Supplier supplier);
        Task<ServiceResponse<bool>> EditSupplier(Supplier supplier, string Id);
        Task<ServiceResponse<bool>> DeleteSupplier(string Id);
        Task<ServiceResponse<List<Warehouse>>> GetWarehouse();
        Task<ServiceResponse<bool>> AddWarehouse(Warehouse warehouse);
        Task<ServiceResponse<bool>> EditWarehouse(Warehouse warehouse, string Id);
        Task<ServiceResponse<bool>> DeleteWarehouse(string Id);
    }
}
