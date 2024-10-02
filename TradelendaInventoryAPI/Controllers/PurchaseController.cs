using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult<(bool Success, string Message)>> AddNewPurchaseAsync(Purchase purchase)
        {
            var result = await _purchaseService.AddNewPurchaseAsync(purchase);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseList()
        {
            var result = await _purchaseService.GetPurchaseList();
            return Ok(result);
        }

        [HttpDelete("{purchaseId}")]
        public async Task<ActionResult<(bool Success, string Message)>> DeletePurchaseAsync(int purchaseId)
        {
            var result = await _purchaseService.DeletePurchaseAsync(purchaseId);
            return Ok(result);
        }

        [HttpPut("{purchaseId}")]
        public async Task<ActionResult<(bool Success, string Message)>> EditPurchaseAsync(int purchaseId, Purchase purchaseDto)
        {
            var result = await _purchaseService.EditPurchaseAsync(purchaseId, purchaseDto);
            return Ok(result);
        }

        [HttpPost("import")]
        public async Task<ActionResult<(bool Success, string Message)>> ImportPurchaseAsync(IFormFile file)
        {
            var result = await _purchaseService.ImportPurchaseAsync(file);
            return Ok(result);
        }

        [HttpGet("report")]
        public async Task<ActionResult<PurchaseOrderReport>> GetPurchaseOrderReportAsync()
        {
            var result = await _purchaseService.GetPurchaseOrderReportAsync();
            return Ok(result);
        }
    }

}
