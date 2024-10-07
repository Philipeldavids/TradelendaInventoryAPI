using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class ProductModel
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Store { get; set; }
        public string? Warehouse { get; set; }

        public string? Category { get; set; }

        public string? CategorySlug { get; set; }

        public string? Brand { get; set; }

        public string? Barcode { get; set; }
        public decimal Price { get; set; }
        public string? Unit { get; set; }
        public int Quantity { get; set; }

        public string? SKU { get; set; }

        public string? ProductImageUrl { get; set; }

        public decimal UnitCost { get; set; }
        public DateTimeOffset ManufacturedDate { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }
    }

}
