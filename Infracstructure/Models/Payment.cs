using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Payment
    {
       
        public DateTime Date { get; set; }
        [Key]
        public string Reference { get; set; }             
        public decimal ReceivedAmount { get; set; }       
        public decimal PayingAmount { get; set; }         
        public PaymentType PaymentType { get; set; }      
        public string Description { get; set; }           
    }

    public enum PaymentType
    {
        Online,   
        Cash      
    }

}
