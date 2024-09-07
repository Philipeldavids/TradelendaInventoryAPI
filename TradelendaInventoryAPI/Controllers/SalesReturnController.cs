using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesReturnController : ControllerBase
    {
        private readonly ISalesReturnService _salesReturnService;

        public SalesReturnController(ISalesReturnService salesReturnService)
        {
            _salesReturnService = salesReturnService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewSalesReturn([FromBody] SalesReturn salesReturn)
        {
            await _salesReturnService.AddNewSalesReturnAsync(salesReturn);
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSalesReturnList()
        {
            return Ok(await _salesReturnService.GetSalesReturnListAsync());
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditSalesReturn([FromBody] SalesReturn salesReturn)
        {
            await _salesReturnService.EditSalesReturnAsync(salesReturn);
            return Ok();
        }

        [HttpDelete("delete/{reference}")]
        public async Task<IActionResult> DeleteSalesReturn(string reference)
        {
            await _salesReturnService.DeleteSalesReturnAsync(reference);
            return Ok();
        }
    }

}
