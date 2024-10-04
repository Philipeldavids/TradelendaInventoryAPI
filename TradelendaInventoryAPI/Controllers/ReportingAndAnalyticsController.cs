using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportingAndAnalyticsController : ControllerBase
    {
        public readonly IReportingAndAnalyticsService _reportingAndAnalytics;
        private readonly IPurchaseService purchaseService;

        public ReportingAndAnalyticsController(IReportingAndAnalyticsService reportingAndAnalytics, IPurchaseService purchaseService)
        {
            _reportingAndAnalytics = reportingAndAnalytics;
            this.purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesReport()
        {
            try
            {
                var report = await _reportingAndAnalytics.GetSalesReport();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseReport()
        {
            try
            {
                var result = await this.purchaseService.GetPurchaseOrderReport();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}