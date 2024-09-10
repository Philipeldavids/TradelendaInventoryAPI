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
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return (true, "Stock added successfully");
        }

        public async Task<IEnumerable<Stock>> GetStockListAsync()
        {
            return await _context.Stocks.Include(s => s.Products).Include(s => s.Warehouse).ToListAsync();
        }

        public async Task<(bool Success, string Message)> EditStockAsync(string stockId, Stock stock)
        {
            var existingStock = await _context.Stocks.FindAsync(stockId);
            if (existingStock != null)
            {
                existingStock.Products = stock.Products;
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
            var stock = await _context.Stocks.FindAsync(stockId);
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
            await _context.StockAdjustments.AddAsync(adjustment);
            await _context.SaveChangesAsync();
            return (true, "Stock adjustment added successfully");
        }

        public async Task<(bool Success, string Message)> EditStockAdjustmentAsync(string adjustmentId, StockAdjustment adjustment)
        {
            var existingAdjustment = await _context.StockAdjustments.FindAsync(adjustmentId);
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
            var adjustment = await _context.StockAdjustments.FindAsync(adjustmentId);
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
            return await _context.StockAdjustments.ToListAsync();
        }

        public async Task<(bool Success, string Message)> StockTransferAsync(StockTransfer transfer)
        {
            await _context.StockTransfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return (true, "Stock transfer completed successfully");
        }

        public async Task<IEnumerable<StockTransfer>> GetStockTransferListAsync()
        {
            return await _context.StockTransfers.Include(st => st.FromWarehouse).Include(st => st.ToWarehouse).ToListAsync();
        }
    }

}
