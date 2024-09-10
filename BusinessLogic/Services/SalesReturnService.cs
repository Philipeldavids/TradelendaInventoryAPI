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

        public async Task<bool> AddNewSalesReturnAsync(SalesReturn salesReturn)
        {
            _context.SalesReturns.Add(salesReturn);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SalesReturn>> GetSalesReturnListAsync()
        {
            return _context.SalesReturns.ToList();
        }

        public async Task<bool> EditSalesReturnAsync(SalesReturn salesReturn)
        {
            var existingReturn = _context.SalesReturns.Where(sr => sr.Reference == salesReturn.Reference).FirstOrDefault();
            if (existingReturn != null)
            {
                existingReturn.Status = salesReturn.Status;
                existingReturn.Product = salesReturn.Product;
                existingReturn.Quantity = salesReturn.Quantity;
                existingReturn.Total = salesReturn.Total;
                _context.SalesReturns.Update(existingReturn);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSalesReturnAsync(string reference)
        {
            var salesReturn = _context.SalesReturns.Where(sr => sr.Reference == reference).FirstOrDefault();
            if (salesReturn != null)
            {
                _context.SalesReturns.Remove(salesReturn);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
