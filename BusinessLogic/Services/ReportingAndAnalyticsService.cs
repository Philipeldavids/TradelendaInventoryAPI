using BusinessLogic.Interfaces;
using DataLayer;
using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
   
    public class ReportingAndAnalyticsService : IReportingAndAnalyticsService
    {
        private readonly ApplicationDbContext _context;

        public ReportingAndAnalyticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesReport>> GetSalesReport()
        {
            var report = _context.SalesReports.ToList();

            return report;
        }

        //public async Task<List<PurchaseReport>> GetPurchaseReport()
        //{
        //    var report = _context.PurchaseReports.ToList();

        //    return report;
        //}
    }
}
