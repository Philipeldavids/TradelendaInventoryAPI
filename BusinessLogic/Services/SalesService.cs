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
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetSalesListAsync()
        {
            return _context.Sales
                .Include(p=>p.Customer)
                .Include(p=>p.Supplier)
                .Include(p=>p.Products).ToList();
        }

        public async Task<Sale> GetSaleDetailAsync(string reference)
        {
            return await _context.Sales.Where(s => s.Reference == reference)
                .Include(p => p.Customer)
                .Include(p => p.Supplier)
                .Include(p => p.Products).FirstOrDefaultAsync();


        }

        public async Task EditSaleAsync(Sale sale)
        {
            var existingSale = _context.Sales.Where(s => s.Reference == sale.Reference).FirstOrDefault();
            if (existingSale != null)
            {
                existingSale.Customer = sale.Customer;
                existingSale.Products = sale.Products;
                existingSale.Discount = sale.Discount;
                existingSale.Supplier = sale.Supplier;                
                existingSale.TaxPercentage = sale.TaxPercentage;
                existingSale.Shipping = sale.Shipping;               
                existingSale.Status = sale.Status;              
                existingSale.Paid = sale.Paid;
                existingSale.Due = sale.Due;
                existingSale.PaymentStatus = sale.PaymentStatus;
                existingSale.Biller = sale.Biller;
                _context.Sales.Update(existingSale);
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
