using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class PurchaseReturn
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceNo { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Shipping { get; set; }
        public decimal OrderTax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
       
    }

}


