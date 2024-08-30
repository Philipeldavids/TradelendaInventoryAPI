using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Customer
    {
        [Key] 
        public string CustomerId { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }

        public List<PurchaseOrder> PurchaseOrders { get; set;}
    }

}
