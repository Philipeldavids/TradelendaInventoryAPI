﻿using Infracstructure.Models;
using Infracstructure.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPeopleService
    {
        Task<bool> AddCustomer(Customer customer);
        Task<bool> AddSupplier(Supplier supplier);
        Task<bool> AddWarehouse(WarehouseModel warehouse);
        Task<bool> AddStore(Store store);
    }
}