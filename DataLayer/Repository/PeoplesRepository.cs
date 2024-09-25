using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PeoplesRepository : IPeoplesRepository
    {
        private readonly ApplicationDbContext _context;
       
        public PeoplesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Store> GetStoreByCode(int code)
        {
            var res = _context.Stores.Where(x => x.SupplierID == code).FirstOrDefault();

            return res;
        }
       public async Task<ServiceResponse<List<Store>>> GetStore()
        {
          var res = _context.Stores.ToList();
            return new ServiceResponse<List<Store>>()
            {
                Data = res,
                Success = true,
                Message = "Stores list Retrieved succesfully"
            };
        }

        public async Task<ServiceResponse<bool>> AddStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>() {  
                Data = true,
                Success = true,
                Message = "Store Created successfully"     
            };
        }

        public async Task<ServiceResponse<bool>> EditStore(Store store, string Id)
        {
            var stor = _context.Stores.Where(x=>x.StoreId == Id).FirstOrDefault();

            if(stor != null)
            {
                stor.StoreName = store.StoreName;
                stor.ContactPerson = store.ContactPerson;
                stor.PhoneNumber = store.PhoneNumber;
                stor.Email = store.Email;
                stor.Status = store.Status;

                _context.Stores.Update(stor);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Store Updated successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Store Updated failed"
            };
        }

        public async Task<ServiceResponse<bool>> DeleteStores(string ID)
        {
            var stor = _context.Stores.Where(x => x.StoreId == ID).FirstOrDefault();

            if(stor != null )
            {
                _context.Stores.Remove(stor);
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool>
                {
                    Data = true,
                    Success = true,
                    Message = "Store deleted successfully"
                };
            }
            return new ServiceResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Store deletion failed"
            };

        }

        public async Task<ServiceResponse<List<Customer>>> GetCustomers()
        {
           var res =  _context.Customers.ToList();
            return new ServiceResponse<List<Customer>>()
            {
                Data = res,
                Success = true,
                Message = "Customers list retrieved successfully"
            };
        }

        public async Task<ServiceResponse<bool>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true,
                Message = "Customer added successfully"
            };

        }

        public async Task<ServiceResponse<bool>> EditCustomer(Customer customer, string Id)
        {
            var customr = _context.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();

            if(customr != null)
            {
                customr.PhoneNumber = customer.PhoneNumber;
                customr.FullName = customer.FullName;
                customr.ShippingAddress = customer.ShippingAddress;
                customr.Code = customer.Code;
                customr.PurchaseOrders = customer.PurchaseOrders;

                _context.Customers.Update(customr);
                _context.SaveChanges();

                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Customer updated successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Customer updated failed"
            };

        }

        public async Task<ServiceResponse<bool>> DeleteCustomer(string Id)
        {
            var customr = _context.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();

            if (customr != null)
            {
                _context.Customers.Remove(customr);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Customer deleted successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Customer deletion failed"
            };
        }

        public async Task<ServiceResponse<List<Supplier>>> GetSupplier()
        {
            var res = _context.Suppliers.ToList();
            return new ServiceResponse<List<Supplier>>()
            {

                Data = res,
                Success = true,
                Message = "Supplier list retrieved successfully"
            };
        }

        public async Task<ServiceResponse<bool>> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true,
                Message = "Supplier added successfully"
            };

        }

        public async Task<ServiceResponse<bool>> EditSupplier(Supplier supplier, string Id)
        {
            var supplir = _context.Suppliers.Where(x => x.SupplierID == Id).FirstOrDefault();

            if (supplir != null)
            {
                supplir.PhoneNumber = supplier.PhoneNumber;
                supplir.Email = supplier.Email;
                supplir.Name = supplier.Name;
                supplir.Country = supplier.Country;
                supplir.Code = supplier.Code;         
      
                _context.Suppliers.Update(supplir);
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Supplier updated successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Supplier updated failed"
            };

        }

        public async Task<ServiceResponse<bool>> DeleteSupplier(string Id)
        {
            var supplr = _context.Suppliers.Where(x => x.SupplierID == Id).FirstOrDefault();

            if (supplr != null)
            {
                _context.Suppliers.Remove(supplr);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Supplier deleted successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Supplier deletion failed"
            };
        }

        
        public async Task<ServiceResponse<List<Warehouse>>> GetWarehouse()
        {
            var res = _context.Warehouses
                .Include(propa => propa.Stock)
                .Include(p=>p.supplier).ToList();

            return new ServiceResponse<List<Warehouse>>()
            {
                Data = res,
                Success = true,
                Message = "Warehouse list retrieved successfully"
            };
        }
       
        public async Task<ServiceResponse<bool>> AddWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true,
                Message = "Warehouse added successfully"
            };

        }
      
        public async Task<ServiceResponse<bool>> EditWarehouse(Warehouse warehouse, string Id)
        {
            var warehous = _context.Warehouses.Where(x => x.WarehouseId == Id)
                .FirstOrDefault();

            if (warehous != null)
            {
                warehous.WarehouseName = warehouse.WarehouseName;
                warehous.ContactPhone = warehouse.ContactPhone;
                warehous.ContactPerson = warehouse.ContactPerson;
                warehous.CreatedOn = warehouse.CreatedOn;
                warehous.Quantity = warehouse.Quantity;
                warehous.Stock = warehouse.Stock;
                warehous.Status = warehouse.Status;
                warehous.Address1 = warehouse.Address1;
                warehous.Address2 = warehouse.Address2;
                warehous.supplier = warehouse.supplier;
                warehous.Stock = warehouse.Stock;
                

                _context.Warehouses.Update(warehous);
                _context.SaveChanges();

                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Supplier updated successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Supplier updated failed"
            };

        }
       
        public async Task<ServiceResponse<bool>> DeleteWarehouse(string Id)
        {
            var warehous = _context.Warehouses.Where(x => x.WarehouseId == Id).FirstOrDefault();

            if (warehous != null)
            {
                _context.Warehouses.Remove(warehous);
                _context.SaveChanges();
                return new ServiceResponse<bool>()
                {
                    Data = true,
                    Success = true,
                    Message = "Supplier deleted successfully"
                };
            }
            return new ServiceResponse<bool>()
            {
                Data = false,
                Success = false,
                Message = "Supplier deletion failed"

            };
        }
    }
}
