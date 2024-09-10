using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.PurchaseDTOs
{
    public class PurchaseOrderReportDto
    {
        public DateTime ReportDate { get; set; } 
        public List<PurchaseSummaryDto> Purchases { get; set; } 
        public decimal TotalPurchaseAmount { get; set; } 
        public decimal TotalTaxAmount { get; set; } 
        public decimal TotalDiscountAmount { get; set; } 
        public decimal TotalPaidAmount { get; set; } 
        public decimal TotalDueAmount { get; set; } 

        public PurchaseOrderReportDto()
        {
            Purchases = new List<PurchaseSummaryDto>();
        }
    }
}
