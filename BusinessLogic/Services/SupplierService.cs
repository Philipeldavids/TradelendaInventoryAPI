using BusinessLogic.Interfaces;
using DataLayer;
using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SupplierService:ISupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> GetSupplierByIdAsync(string supplierId)
        {
           
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(s => s.SupplierID == supplierId);

            return supplier;
        }
    }
}
