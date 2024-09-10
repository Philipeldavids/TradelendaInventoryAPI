using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.PurchaseDTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ProductName { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public List<string> ProductIds { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal Shipping { get; set; }
    }
}
