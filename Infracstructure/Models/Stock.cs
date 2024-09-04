using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Stock
    {
        public string StockId { get; set; } = Guid.NewGuid().ToString();
        public string WarehouseID { get; set; }
        public List<Product> Products { get; set; }

        public DateTime DateAdded { get; set; }
        
        public string Person { get; set; }

        public string Quantity { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}
