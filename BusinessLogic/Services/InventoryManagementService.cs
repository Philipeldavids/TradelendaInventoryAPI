using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
