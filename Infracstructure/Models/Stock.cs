using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Stock
    {
        public string StockId { get; set; } = Guid.NewGuid().ToString();
        public string WarehouseID { get; set; }       

        public DateTime DateAdded { get; set; }

        public List<Product>? Products { get; set; } = new List<Product>();
        
        public string? Person { get; set; }

        public int? Quantity { get; set; }        
       

    }

    public class StockAdjustment
    {
        public string StockAdjustmentId { get; set; } = Guid.NewGuid().ToString();
        public string StockId { get; set; }
        public int QuantityAdjusted { get; set; }
        public string Reason { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public string AdjustedBy { get; set; }
    }

    public class StockTransfer
    {
        public string StockTransferId { get; set; } = Guid.NewGuid().ToString();        
        public int QuantityTransferred { get; set; }

        public List<Product> ProductMoved { get; set; } = new List<Product>();

        public string? Notes { get; set; }
        public string? RefNumber { get; set; }
        public DateTime TransferDate { get; set; }
        public Warehouse FromWarehouse { get; set; }
        public Warehouse ToWarehouse { get; set; }
    }

}
