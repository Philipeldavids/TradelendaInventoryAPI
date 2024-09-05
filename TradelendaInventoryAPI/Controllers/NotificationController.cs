using BusinessLogic.Interfaces;
using Infracstructure.DTOs.NotificationDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("new-product-added")]
        public async Task<IActionResult> AlertNewProductAddedAsync([FromBody] NewProductNotificationRequest request)
        {
            await _notificationService.AlertNewProductAddedAsync(request.Product, request.RecipientEmail);
            return Ok("Notification sent successfully");
        }

        [HttpPost("new-stock-added")]
        public async Task<IActionResult> AlertNewStockAsync([FromBody] NewStockNotificationRequest request)
        {
            await _notificationService.AlertNewStockAsync(request.Stock, request.RecipientEmail);
            return Ok("Notification sent successfully");
        }

        [HttpPost("new-store-created")]
        public async Task<IActionResult> AlertNewStoreCreatedAsync([FromBody] NewStoreNotificationRequest request)
        {
            await _notificationService.AlertNewStoreCreatedAsync(request.Store, request.RecipientEmail);
            return Ok("Notification sent successfully");
        }

        [HttpPost("new-purchase-added")]
        public async Task<IActionResult> AlertNewPurchaseAsync([FromBody] NewPurchaseNotificationRequest request)
        {
            await _notificationService.AlertNewPurchaseAsync(request.PurchaseOrder, request.RecipientEmail);
            return Ok("Notification sent successfully");
        }
    }

}
