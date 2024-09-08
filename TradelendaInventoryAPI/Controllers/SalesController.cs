using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewSale([FromBody] Sale sale)
        {
            var res = _salesService.AddNewSaleAsync(sale);
            return Ok(res);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSalesList()
        {
            return Ok(await _salesService.GetSalesListAsync());
        }

        [HttpGet("detail/{reference}")]
        public async Task<IActionResult> GetSaleDetail(string reference)
        {
            return Ok(await _salesService.GetSaleDetailAsync(reference));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditSale([FromBody] Sale sale)
        {
            var res = _salesService.EditSaleAsync(sale);
            return Ok(res);
        }

        [HttpDelete("delete/{reference}")]
        public async Task<IActionResult> DeleteSale(string reference)
        {
            var res = _salesService.DeleteSaleAsync(reference);
            return Ok(res);
        }

        [HttpGet("download-pdf/{reference}")]
        public async Task<IActionResult> DownloadPdf(string reference)
        {
            var pdfData = await _salesService.DownloadPdfAsync(reference);
            return File(pdfData, "application/pdf", $"{reference}.pdf");
        }

        [HttpGet("download-excel/{reference}")]
        public async Task<IActionResult> DownloadExcel(string reference)
        {
            var excelData = await _salesService.DownloadExcelAsync(reference);
            return File(excelData, "application/vnd.ms-excel", $"{reference}.xlsx");
        }
    }

}
