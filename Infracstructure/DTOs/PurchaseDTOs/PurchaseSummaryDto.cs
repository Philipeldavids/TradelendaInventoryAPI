using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.PurchaseDTOs
{
    public class PurchaseSummaryDto
    {
        public int PurchaseId { get; set; } 
        public string SupplierName { get; set; } 
        public DateTime PurchaseDate { get; set; } 
        public string ProductName { get; set; }
        public decimal TotalCost { get; set; } 
        public decimal Paid { get; set; } 
        public decimal Due { get; set; } 
        public decimal TaxAmount { get; set; } 
        public decimal Discount { get; set; } 
    }

}
