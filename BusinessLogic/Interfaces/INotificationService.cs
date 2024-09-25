using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface INotificationService
    {
        Task AlertNewProductAddedAsync(Product product, string recipientEmail);
        //Task AlertNewStockAsync(Stock stock, string recipientEmail);
        Task AlertNewStoreCreatedAsync(Store store, string recipientEmail);
        //Task AlertNewSalesAsync(Sale sale, string recipientEmail);
        Task AlertNewPurchaseAsync(PurchaseOrder purchase, string recipientEmail);
        //Generic method
        Task SendNotificationAsync<T>(T entity, string recipientEmail, string subject, Func<T, string> messageBuilder);
    }
}
