using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Notification.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BusinessLogic.Hubs;

namespace BusinessLogic.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly IHubContext<NotificationServiceHub> _hubContext;

        public NotificationService(IEmailService emailService, IHubContext<NotificationServiceHub> hubContext)
        {
            _emailService = emailService;
            _hubContext = hubContext;
        }

        public async Task AlertNewProductAddedAsync(Product product, string recipientEmail)
        {
            var mailRequestDto = new MailRequestDto
            {
                ToEmail = recipientEmail,
                Subject = "New product added",
                Message = $"Product name: {product.ProductName}"
            };
            await _emailService.SendEmailAsync(mailRequestDto);

         
            string notificationMessage = $"A new product '{product.ProductName}' has been added!";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }

        public async Task AlertNewStockAsync(Stock stock, string recipientEmail)
        {
            var mailRequestDto = new MailRequestDto
            {
                ToEmail = recipientEmail,
                Subject = "New stock added",
                Message = $"Product name: {stock.Products}, Quantity: {stock.Quantity}"
            };
            await _emailService.SendEmailAsync(mailRequestDto);

            
            string notificationMessage = $"New stock for '{stock.Products}' (Quantity: {stock.Quantity}) has been added!";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }

        public async Task AlertNewStoreCreatedAsync(Store store, string recipientEmail)
        {
            var mailRequestDto = new MailRequestDto
            {
                ToEmail = recipientEmail,
                Subject = "New store created",
                Message = $"Store name: {store.StoreName}"
            };
            await _emailService.SendEmailAsync(mailRequestDto);

           
            string notificationMessage = $"A new store '{store.StoreName}' has been created!";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }

        public async Task AlertNewPurchaseAsync(PurchaseOrder purchase, string recipientEmail)
        {
            var mailRequestDto = new MailRequestDto
            {
                ToEmail = recipientEmail,
                Subject = "New purchase",
                Message = $"Product name: {purchase.Items}, Order Id: {purchase.OrderId}"
            };
            await _emailService.SendEmailAsync(mailRequestDto);

            
            string notificationMessage = $"A new purchase (Order Id: {purchase.OrderId}) has been made!";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationMessage);
        }
    }

}
