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
        
        public string Person { get; set; }

        public string Quantity { get; set; }        
       

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
        public DateTime TransferDate { get; set; }
        public Warehouse FromWarehouse { get; set; }
        public Warehouse ToWarehouse { get; set; }
    }

}
