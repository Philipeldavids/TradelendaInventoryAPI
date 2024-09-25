using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {

        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost("add-new-stock")]
        public async Task<IActionResult> AddNewStock([FromBody] Stock stock)
        {
            var result = await _stockService.AddNewStockAsync(stock);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get-stock-list")]
        public async Task<IActionResult> GetStockList()
        {
            var stockList = await _stockService.GetStockListAsync();
            if(stockList != null)
            {
                return Ok(stockList);
            }
            return BadRequest();
        }

        [HttpPut("edit-stock/{stockId}")]
        public async Task<IActionResult> EditStock(string stockId, [FromBody] Stock stock)
        {
            var result = await _stockService.EditStockAsync(stockId, stock);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpDelete("delete-stock/{stockId}")]
        public async Task<IActionResult> DeleteStock(string stockId)
        {
            var result = await _stockService.DeleteStockAsync(stockId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpPost("add-new-stock-adjustment")]
        public async Task<IActionResult> AddNewStockAdjustment([FromBody] StockAdjustment adjustment)
        {
            var result = await _stockService.AddNewStockAdjustmentAsync(adjustment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("edit-stock-adjustment/{adjustmentId}")]
        public async Task<IActionResult> EditStockAdjustment(string adjustmentId, [FromBody] StockAdjustment adjustment)
        {
            var result = await _stockService.EditStockAdjustmentAsync(adjustmentId, adjustment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpDelete("delete-stock-adjustment/{adjustmentId}")]
        public async Task<IActionResult> DeleteStockAdjustment(string adjustmentId)
        {
            var result = await _stockService.DeleteStockAdjustmentAsync(adjustmentId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpGet("get-stock-adjustment-list")]
        public async Task<IActionResult> GetStockAdjustmentList()
        {
            var adjustmentList = await _stockService.GetStockAdjustmentListAsync();
            return Ok(adjustmentList);
        }

        [HttpPost("stock-transfer")]
        public async Task<IActionResult> StockTransfer([FromBody] StockTransfer transfer)
        {
            var result = await _stockService.StockTransferAsync(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get-stock-transfer-list")]
        public async Task<IActionResult> GetStockTransferList()
        {
            var transferList = await _stockService.GetStockTransferListAsync();
            return Ok(transferList);
        }
        
    }

}
