using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IStockService
    {
        Task<(bool Success, string Message)> AddNewStockAsync(Stock stock);
        Task<IEnumerable<Stock>> GetStockListAsync();
        Task<(bool Success, string Message)> EditStockAsync(string stockId, Stock stock);
        Task<(bool Success, string Message)> DeleteStockAsync(string stockId);
        Task<(bool Success, string Message)> AddNewStockAdjustmentAsync(StockAdjustment adjustment);
        Task<(bool Success, string Message)> EditStockAdjustmentAsync(string adjustmentId, StockAdjustment adjustment);
        Task<(bool Success, string Message)> DeleteStockAdjustmentAsync(string adjustmentId);
        Task<IEnumerable<StockAdjustment>> GetStockAdjustmentListAsync();
        Task<(bool Success, string Message)> StockTransferAsync(StockTransfer transfer);
        Task<IEnumerable<StockTransfer>> GetStockTransferListAsync();
    }
}
