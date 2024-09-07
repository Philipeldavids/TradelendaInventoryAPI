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
    public class SalesReturnService : ISalesReturnService
    {
        private readonly ApplicationDbContext _context;

        public SalesReturnService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewSalesReturnAsync(SalesReturn salesReturn)
        {
            await _context.SalesReturns.AddAsync(salesReturn);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SalesReturn>> GetSalesReturnListAsync()
        {
            return await _context.SalesReturns.ToListAsync();
        }

        public async Task EditSalesReturnAsync(SalesReturn salesReturn)
        {
            var existingReturn = await _context.SalesReturns.FirstOrDefaultAsync(sr => sr.Reference == salesReturn.Reference);
            if (existingReturn != null)
            {
                existingReturn.Status = salesReturn.Status;
                existingReturn.Product = salesReturn.Product;
                existingReturn.Quantity = salesReturn.Quantity;
                existingReturn.Total = salesReturn.Total;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSalesReturnAsync(string reference)
        {
            var salesReturn = await _context.SalesReturns.FirstOrDefaultAsync(sr => sr.Reference == reference);
            if (salesReturn != null)
            {
                _context.SalesReturns.Remove(salesReturn);
                await _context.SaveChangesAsync();
            }
        }
    }
}
