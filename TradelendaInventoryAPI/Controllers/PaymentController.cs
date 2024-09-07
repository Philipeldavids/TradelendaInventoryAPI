using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            await _paymentService.CreatePaymentAsync(payment);
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetPayments()
        {
            return Ok(await _paymentService.GetPaymentsAsync());
        }

        [HttpDelete("delete/{reference}")]
        public async Task<IActionResult> DeletePayment(string reference)
        {
            await _paymentService.DeletePaymentAsync(reference);
            return Ok();
        }
    }

}
