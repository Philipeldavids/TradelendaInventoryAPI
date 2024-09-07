using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Sale
    {
        public string CustomerName { get; set; }         
        public string Reference { get; set; }             
        public DateTime Date { get; set; }                
        public string Status { get; set; }                
        public decimal Total { get; set; }                
        public decimal Paid { get; set; }                 
        public decimal Due { get; set; }                  
        public string PaymentStatus { get; set; }         
        public string Biller { get; set; }                
    }

}
