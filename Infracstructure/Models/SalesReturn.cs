using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class SalesReturn
    {
       
        public Customer Customer { get; set; }            
        public DateTime Date { get; set; }
        [Key]
        public string Reference { get; set; }             
        public string Status { get; set; }                
        public Product Product { get; set; }              
        public decimal NetUnitPrice { get; set; }         
        public decimal Stock { get; set; }                
        public int Quantity { get; set; }                 
        public decimal Discount { get; set; }             
        public decimal Tax { get; set; }                  
        public decimal Shipping { get; set; }             
        public decimal Total { get; set; }                
    }

}
