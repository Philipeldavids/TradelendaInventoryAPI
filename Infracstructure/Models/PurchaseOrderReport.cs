using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class PurchaseOrderReport
    {
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalItems { get; set; }
    }

}
