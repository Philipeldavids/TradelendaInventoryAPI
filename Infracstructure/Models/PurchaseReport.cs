using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infracstructure.Models
{
    public class PurchaseReport
    {
        //[Key]
       // public string PurcahseReportId { get; set; }
       // public string ProductName { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int PurchaseQuatity { get; set; }
        public int InstockQty { get; set; }
    }
}
