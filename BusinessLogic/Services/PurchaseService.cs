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
    //public class PurchaseService : IPurchaseService
    //{
    //    private readonly ApplicationDbContext _context;

    //    public PurchaseService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<(bool Success, string Message)> AddNewPurchaseAsync(PurchaseDto purchaseDto)
    //    {
    //        var supplier = await _context.Suppliers.FindAsync(purchaseDto.SupplierId);
    //        var products =  _context.Products
    //                                     .Where(p => purchaseDto.ProductIds.Contains(purchaseDto.ProductIds.ToString())).ToList();


    //        var purchase = new Purchase
    //        {
    //            Supplier = supplier,
    //            PurchaseDate = purchaseDto.PurchaseDate,
    //            ProductName = purchaseDto.ProductName,
    //            Reference = purchaseDto.Reference,
    //            Status = purchaseDto.Status,
    //            Paid = purchaseDto.Paid,
    //            Due = purchaseDto.Due,
    //            Products = products,
    //            Discount = purchaseDto.Discount,
    //            TaxPercentage = purchaseDto.TaxPercentage,
    //            Shipping = purchaseDto.Shipping
    //        };

    //        _context.Purchases.Add(purchase);
    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase added successfully") : (false, "Failed to add purchase");
    //    }

    //    public async Task<IEnumerable<PurchaseDto>> GetPurchaseListAsync()
    //    {
    //        var purchases = await _context.Purchases
    //                                      .Include(p => p.Supplier)
    //                                      .Include(p => p.Products)
    //                                      .ToListAsync();

    //        return purchases.Select(p => new PurchaseDto
    //        {
    //            Id = p.Id,
    //            SupplierId = p.Supplier.SupplierID,
    //            PurchaseDate = p.PurchaseDate,
    //            ProductName = p.ProductName,
    //            Reference = p.Reference,
    //            Status = p.Status,
    //            Paid = p.Paid,
    //            Due = p.Due,
    //            ProductIds = p.Products.Select(prod => prod.ProductId.ToString()).ToList(),
    //            Discount = p.Discount,
    //            TaxPercentage = p.TaxPercentage,
    //            Shipping = p.Shipping
    //        });
    //    }

    //    public async Task<(bool Success, string Message)> DeletePurchaseAsync(int purchaseId)
    //    {
    //        var purchase = await _context.Purchases.FindAsync(purchaseId);
    //        if (purchase == null) return (false, "Purchase not found");

    //        _context.Purchases.Remove(purchase);
    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase deleted successfully") : (false, "Failed to delete purchase");
    //    }

    //    public async Task<(bool Success, string Message)> EditPurchaseAsync(int purchaseId, PurchaseDto purchaseDto)
    //    {
    //        var purchase = await _context.Purchases
    //                                     .Include(p => p.Products)
    //                                     .FirstOrDefaultAsync(p => p.Id == purchaseId);

    //        if (purchase == null) return (false, "Purchase not found");

    //        var supplier = await _context.Suppliers.FindAsync(purchaseDto.SupplierId);
    //        var products = await _context.Products
    //                                     .Where(p => purchaseDto.ProductIds.Contains(p.ProductId))
    //                                     .ToListAsync();

    //        purchase.Supplier = supplier;
    //        purchase.PurchaseDate = purchaseDto.PurchaseDate;
    //        purchase.ProductName = purchaseDto.ProductName;
    //        purchase.Reference = purchaseDto.Reference;
    //        purchase.Status = purchaseDto.Status;
    //        purchase.Paid = purchaseDto.Paid;
    //        purchase.Due = purchaseDto.Due;
    //        purchase.Products = products;
    //        purchase.Discount = purchaseDto.Discount;
    //        purchase.TaxPercentage = purchaseDto.TaxPercentage;
    //        purchase.Shipping = purchaseDto.Shipping;

    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase updated successfully") : (false, "Failed to update purchase");
    //    }

    //    public async Task<(bool Success, string Message)> ImportPurchaseAsync(IFormFile file)
    //    {
    //        // Implement import logic here
    //        return (true, "Purchases imported successfully");
    //    }

    //    public async Task<PurchaseOrderReportDto> GetPurchaseOrderReportAsync()
    //    {
    //        // Implement report generation logic here
    //        return new PurchaseOrderReportDto();
    //    }

    //    public async Task<(bool Success, string Message)> AddPurchaseReturnAsync(PurchaseReturn purchaseReturn)
    //    {
    //        //var purchase = await _context.Purchases.FindAsync(purchaseReturnDto.PurchaseId);                   

    //        _context.PurchaseReturns.Add(purchaseReturn);
    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase return added successfully") : (false, "Failed to add purchase return");
    //    }

    //    public async Task<IEnumerable<PurchaseReturn>> GetPurchaseReturnListAsync()
    //    {
    //        var purchaseReturns = await _context.PurchaseReturns.ToListAsync();

    //        return purchaseReturns;
    //    }

    //    public async Task<(bool Success, string Message)> EditPurchaseReturnAsync(int purchaseReturnId, PurchaseReturnDto purchaseReturnDto)
    //    {
    //        var purchaseReturn = await _context.PurchaseReturns                                               
    //                                           .FirstOrDefaultAsync(pr => pr.Id == purchaseReturnId);

    //        if (purchaseReturn == null) return (false, "Purchase return not found");

    //        var purchase = await _context.Purchases.FindAsync(purchaseReturnDto.PurchaseId);



    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase return updated successfully") : (false, "Failed to update purchase return");
    //    }

    //    public async Task<(bool Success, string Message)> DeletePurchaseReturnAsync(int purchaseReturnId)
    //    {
    //        var purchaseReturn = await _context.PurchaseReturns.FindAsync(purchaseReturnId);
    //        if (purchaseReturn == null) return (false, "Purchase return not found");

    //        _context.PurchaseReturns.Remove(purchaseReturn);
    //        var result = await _context.SaveChangesAsync() > 0;
    //        return result ? (true, "Purchase return deleted successfully") : (false, "Failed to delete purchase return");
    //    }

    //    public Task<(bool Success, string Message)> AddPurchaseReturnAsync(PurchaseReturnDto purchaseReturnDto)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<IEnumerable<PurchaseReturnDto>> IPurchaseService.GetPurchaseReturnListAsync()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

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

        public async Task<IEnumerable<Purchase>> GetPurchaseListAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<(bool Success, string Message)> DeletePurchaseAsync(int purchaseId)
        {
            var purchase = await _context.Purchases.FindAsync(purchaseId);
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
            var purchase = await _context.Purchases.FindAsync(purchaseId);
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
                            Supplier = await _context.Suppliers.FindAsync(csvReader["SupplierId"]),
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

        public async Task<PurchaseOrderReport> GetPurchaseOrderReportAsync()
        {
          
            var totalOrders = await _context.Purchases.CountAsync();
            var totalAmount = await _context.Purchases.SumAsync(p => p.Paid* p.Products.Count);
            var totalItems = await _context.Purchases.SumAsync(p => p.Products.Count);

            var report = new PurchaseOrderReport
            {
                TotalOrders = totalOrders,
                TotalAmount = totalAmount,
                TotalItems = totalItems
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
