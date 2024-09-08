using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Sale
    {
             
        public Customer Customer{ get; set; } 
        public Supplier Supplier { get; set; }

        public List<Product> Products { get; set; }
        [Key]
        public string Reference { get; set; }             
        public DateTime Date { get; set; }                
        public string Status { get; set; }                
                      
        public decimal Paid { get; set; }                 
        public decimal Due { get; set; }                  
        public string PaymentStatus { get; set; }         
        public string Biller { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal TaxAmount
        {
            get
            {
                return (TotalPrice - Discount) * (TaxPercentage / 100);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Products?.Sum(p => p.Price * p.Quantity) ?? 0;
            }
        }

        public decimal Shipping { get; set; }
    }

}
