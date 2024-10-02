using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarCodeService _barcodeService;

        public BarcodeController(IBarCodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }


        [HttpGet("barcode")]
        public IActionResult GenerateBarcode([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Text cannot be empty.");
            }

            var barcodeImage = _barcodeService.GenerateBarcode(text);

            using var memoryStream = new MemoryStream(barcodeImage);

            return File(memoryStream, "image/png");
        }


        [HttpGet("qrcode")]
        public IActionResult GenerateQRCode([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Text cannot be empty.");
            }

            var qrCodeImage = _barcodeService.GenerateQRCode(text);

            using var memoryStream = new MemoryStream(qrCodeImage);
            return File(memoryStream, "image/png");
        }
    }
}
