using BusinessLogic.Interfaces;
using DataLayer;
using Infracstructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SalesService : ISalesService
    {
        private readonly ApplicationDbContext _context;

        public SalesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewSaleAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetSalesListAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetSaleDetailAsync(string reference)
        {
            return await _context.Sales.FirstOrDefaultAsync(s => s.Reference == reference);
        }

        public async Task EditSaleAsync(Sale sale)
        {
            var existingSale = await _context.Sales.FirstOrDefaultAsync(s => s.Reference == sale.Reference);
            if (existingSale != null)
            {
                existingSale.CustomerName = sale.CustomerName;
                existingSale.Status = sale.Status;
                existingSale.Total = sale.Total;
                existingSale.Paid = sale.Paid;
                existingSale.Due = sale.Due;
                existingSale.PaymentStatus = sale.PaymentStatus;
                existingSale.Biller = sale.Biller;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSaleAsync(string reference)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(s => s.Reference == reference);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<byte[]> DownloadPdfAsync(string reference)
        {
            // Logic to generate and return PDF
            return new byte[0]; // Dummy PDF data
        }

        public async Task<byte[]> DownloadExcelAsync(string reference)
        {
            // Logic to generate and return Excel file
            return new byte[0]; // Dummy Excel data
        }
    }
}
