using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IReportingAndAnalyticsService
    {
        Task<List<SalesReport>> GetSalesReport();
        //Task<List<PurchaseReport>> GetPurchaseReport();
    }
}
