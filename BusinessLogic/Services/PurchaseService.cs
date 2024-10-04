using BusinessLogic.Interfaces;
using CsvHelper;
using DataLayer;
using Infracstructure.DTOs.PurchaseDTOs;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{

    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext _context;

        public PurchaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> AddNewPurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return (true, "Purchase added successfully");
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseList()
        {
            return _context.Purchases.ToList();
        }

        public async Task<(bool Success, string Message)> DeletePurchaseAsync(int purchaseId)
        {
            var purchase = _context.Purchases.Find(purchaseId);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
                return (true, "Purchase deleted successfully");
            }
            return (false, "Purchase not found");
        }

        public async Task<(bool Success, string Message)> EditPurchaseAsync(int purchaseId, Purchase purchaseDto)
        {
            var purchase = _context.Purchases.Find(purchaseId);
            if (purchase != null)
            {
                purchase.Supplier = _context.Suppliers.Find(purchaseDto.Supplier.SupplierID);
                purchase.CreatedBy = purchaseDto.CreatedBy;
                purchase.Reference = purchaseDto.Reference;
                
                await _context.SaveChangesAsync();
                return (true, "Purchase edited successfully");
            }
            return (false, "Purchase not found");
        }

        public async Task<(bool Success, string Message)> ImportPurchaseAsync(IFormFile file)
        {
            try
            {
                // Check if the file is valid
                if (file == null || file.Length == 0)
                {
                    return (false, "Invalid file");
                }
              
                var extension = Path.GetExtension(file.FileName);
                if (extension != ".csv")
                {
                    return (false, "Only CSV files are allowed");
                }

                // Read the CSV file
                var purchases = new List<Purchase>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csvReader.Read();
                    csvReader.ReadHeader();
                    while (csvReader.Read())
                    {
                        var purchase = new Purchase
                        {
                            Supplier = _context.Suppliers.Find(csvReader["SupplierId"]),
                            CreatedBy = DateTime.Parse(csvReader["Date"]).ToString(),
                            Reference = csvReader["ReferenceNo"],
                            
                        };
                        purchases.Add(purchase);
                    }
                }

                // Add the purchases to the database
                _context.Purchases.AddRange(purchases);
                await _context.SaveChangesAsync();

                return (true, "Purchases imported successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error importing purchases: {ex.Message}");
            }
        }

        public async Task<PurchaseReport> GetPurchaseOrderReport()
        {
          
            var totalOrders =  _context.Purchases.Count();
            var totalproducts = _context.Purchases.Select(x => x.Products).Count();
            var totalAmount = _context.Purchases.Sum(p => p.Paid);       

            var report = new PurchaseReport
            {

                PurchaseQuatity = totalOrders,
                PurchaseAmount = totalAmount,
                InstockQty = totalproducts
            };

            return report;
            
        }

        public async Task<(bool Success, string Message)> AddPurchaseReturnAsync(PurchaseReturn purchaseReturn)
        {
            _context.PurchaseReturns.Add(purchaseReturn);
            await _context.SaveChangesAsync();
            return (true, "Purchase return added successfully");
        }

        public async Task<IEnumerable<PurchaseReturn>> GetPurchaseReturnListAsync()
        {
            return await _context.PurchaseReturns.ToListAsync();
        }

        public async Task<(bool Success, string Message)> EditPurchaseReturnAsync(int purchaseReturnId, PurchaseReturn purchaseReturn)
        {
            var existingPurchaseReturn = await _context.PurchaseReturns.FindAsync(purchaseReturnId);
            if (existingPurchaseReturn != null)
            {
                existingPurchaseReturn.Supplier = _context.Suppliers.Find(purchaseReturn.Supplier.SupplierID);
                existingPurchaseReturn.Date = purchaseReturn.Date;
                existingPurchaseReturn.ReferenceNo = purchaseReturn.ReferenceNo;
                // ...
                await _context.SaveChangesAsync();
                return (true, "Purchase return edited successfully");
            }
            return (false, "Purchase return not found");
        }

        public async Task<(bool Success, string Message)> DeletePurchaseReturnAsync(int purchaseReturnId)
        {
            var purchaseReturn = await _context.PurchaseReturns.FindAsync(purchaseReturnId);
            if (purchaseReturn != null)
            {
                _context.PurchaseReturns.Remove(purchaseReturn);
                await _context.SaveChangesAsync();
                return (true, "Purchase return deleted successfully");
            }
            return (false, "Purchase return not found");
        }
    }

}
