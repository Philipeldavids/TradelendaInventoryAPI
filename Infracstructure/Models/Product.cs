using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infracstructure.Models.Enums;

namespace Infracstructure.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; } 
        public Category Category { get; set; }
        public Brand Brand { get; set; }

        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public bool IsExpired { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }

        public string CreatedBy { get; set; }

      
        public string SKU { get; set; }
       
       
        public DateTime CreatedAt { get; set; }
       

    }
}
