using Infracstructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class SalesReport
    {
        [Key]
        public string SalesReportId { get; set; } = Guid.NewGuid().ToString();
        public Product ProductName { get; set; }        
        public Category Category {  get; set; }
        public Brand brand { get; set; }

        public int SoldQuantiy { get; set; }

        public decimal SoldAmount { get; set; }

        public int InStockQuantity { get; set; }

    }
}
