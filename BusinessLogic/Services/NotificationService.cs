﻿using BusinessLogic.Interfaces;
using Infracstructure.Models;
using Notification.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
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
        }

        //public async Task AlertNewSalesAsync(Sale sale, string recipientEmail)
        //{
        //    var mailRequestDto = new MailRequestDto
        //    {
        //        ToEmail = recipientEmail,
        //        Subject = "New sale",
        //        Message = $"Product name: {sale.ProductName}, Quantity: {sale.Quantity}"
        //    };
        //    await _emailService.SendEmailAsync(mailRequestDto);
        //}

        public async Task AlertNewPurchaseAsync(PurchaseOrder purchase, string recipientEmail)
        {
            var mailRequestDto = new MailRequestDto
            {
                ToEmail = recipientEmail, 
                Subject = "New purchase",
                Message = $"Product name: {purchase.Items}, Order Id: {purchase.OrderId}"
            };
            await _emailService.SendEmailAsync(mailRequestDto);
        }
    }

}