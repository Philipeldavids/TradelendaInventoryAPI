using Infracstructure.DTOs.PurchaseDTOs;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPurchaseService
    {
        Task<(bool Success, string Message)> AddNewPurchaseAsync(Purchase purchase);
        Task<IEnumerable<Purchase>> GetPurchaseList();
        Task<(bool Success, string Message)> DeletePurchaseAsync(int purchaseId);
        Task<(bool Success, string Message)> EditPurchaseAsync(int purchaseId, Purchase purchase);
        Task<(bool Success, string Message)> ImportPurchaseAsync(IFormFile file);
        Task<PurchaseReport> GetPurchaseOrderReport();

       // Task<PurchaseOrderReport> GetPurchaseOrderReportAsync();
        Task<(bool Success, string Message)> AddPurchaseReturnAsync(PurchaseReturn purchaseReturn);
        Task<IEnumerable<PurchaseReturn>> GetPurchaseReturnListAsync();
        Task<(bool Success, string Message)> EditPurchaseReturnAsync(int purchaseReturnId, PurchaseReturn purchaseReturn);
        Task<(bool Success, string Message)> DeletePurchaseReturnAsync(int purchaseReturnId);
    }

}
