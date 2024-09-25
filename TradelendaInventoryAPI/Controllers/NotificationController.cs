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

        //[HttpPost("new-stock-added")]
        //public async Task<IActionResult> AlertNewStockAsync([FromBody] NewStockNotificationRequest request)
        //{
        //    await _notificationService.AlertNewStockAsync(request.Stock, request.RecipientEmail);
        //    return Ok("Notification sent successfully");
        //}

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




        //for the generic method


        [HttpPost("new-product-added2")]
        public async Task<IActionResult> AlertNewProductAddedAsync2([FromBody] NewProductNotificationRequest request)
        {
            await _notificationService.SendNotificationAsync(
                request.Product,
                request.RecipientEmail,
                "New product added",
                product => $"Product name: {product.ProductName}"
            );
            return Ok("Product notification sent successfully");
        }

        [HttpPost("new-stock-added2")]
        //public async Task<IActionResult> AlertNewStockAddedAsync2([FromBody] NewStockNotificationRequest request)
        //{
        //    await _notificationService.SendNotificationAsync(
        //        request.Stock,
        //        request.RecipientEmail,
        //        "New stock added",
        //        stock => $"Product name: {stock.Product}, Quantity: {stock.Quantity}"
        //    );
        //    return Ok("Stock notification sent successfully");
        //}

        [HttpPost("new-store-created2")]
        public async Task<IActionResult> AlertNewStoreCreatedAsync2([FromBody] NewStoreNotificationRequest request)
        {
            await _notificationService.SendNotificationAsync(
                request.Store,
                request.RecipientEmail,
                "New store created",
                store => $"Store name: {store.StoreName}"
            );
            return Ok("Store notification sent successfully");
        }

        [HttpPost("new-purchase-added2")]
        public async Task<IActionResult> AlertNewPurchaseAddedAsync([FromBody] NewPurchaseNotificationRequest request)
        {
            await _notificationService.SendNotificationAsync(
                request.PurchaseOrder,
                request.RecipientEmail,
                "New purchase",
                purchase => $"Product name: {purchase.Items}, Order Id: {purchase.OrderId}"
            );
            return Ok("Purchase notification sent successfully");
        }

    }
}
