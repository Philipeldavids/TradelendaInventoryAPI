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
   
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext _context;

        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> AddNewStockAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return (true, "Stock added successfully");
        }

        public async Task<IEnumerable<Stock>> GetStockListAsync()
        {
            return _context.Stocks.ToList();

        }

        public async Task<(bool Success, string Message)> EditStockAsync(string stockId, Stock stock)
        {
            var existingStock = _context.Stocks.Where(x=>x.StockId == stockId).FirstOrDefault();
            if (existingStock != null)
            {
               
                existingStock.Quantity = stock.Quantity;
                existingStock.Person = stock.Person;
                existingStock.WarehouseID = stock.WarehouseID;
                await _context.SaveChangesAsync();
                return (true, "Stock updated successfully");
            }
            return (false, "Stock not found");
        }

        public async Task<(bool Success, string Message)> DeleteStockAsync(string stockId)
        {
            var stock = _context.Stocks.Where(x => x.StockId == stockId).FirstOrDefault();
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                return (true, "Stock deleted successfully");
            }
            return (false, "Stock not found");
        }

        public async Task<(bool Success, string Message)> AddNewStockAdjustmentAsync(StockAdjustment adjustment)
        {
            _context.StockAdjustments.Add(adjustment);
            await _context.SaveChangesAsync();
            return (true, "Stock adjustment added successfully");
        }

        public async Task<(bool Success, string Message)> EditStockAdjustmentAsync(string adjustmentId, StockAdjustment adjustment)
        {
            var existingAdjustment = _context.StockAdjustments.Where(x=>x.StockAdjustmentId == adjustmentId).FirstOrDefault();
            if (existingAdjustment != null)
            {
                existingAdjustment.QuantityAdjusted = adjustment.QuantityAdjusted;
                existingAdjustment.Reason = adjustment.Reason;
                await _context.SaveChangesAsync();
                return (true, "Stock adjustment updated successfully");
            }
            return (false, "Stock adjustment not found");
        }

        public async Task<(bool Success, string Message)> DeleteStockAdjustmentAsync(string adjustmentId)
        {
            var adjustment = _context.StockAdjustments.Where(x=>x.StockAdjustmentId == adjustmentId).FirstOrDefault();
            if (adjustment != null)
            {
                _context.StockAdjustments.Remove(adjustment);
                await _context.SaveChangesAsync();
                return (true, "Stock adjustment deleted successfully");
            }
            return (false, "Stock adjustment not found");
        }

        public async Task<IEnumerable<StockAdjustment>> GetStockAdjustmentListAsync()
        {
            return _context.StockAdjustments.ToList();
        }

        public async Task<(bool Success, string Message)> StockTransferAsync(StockTransfer transfer)
        {
            _context.StockTransfers.Add(transfer);
            await _context.SaveChangesAsync();
            return (true, "Stock transfer completed successfully");
        }

        public async Task<IEnumerable<StockTransfer>> GetStockTransferListAsync()
        {
            return _context.StockTransfers.Include(st => st.FromWarehouse).Include(st => st.ToWarehouse).ToList();
        }
    }

}
