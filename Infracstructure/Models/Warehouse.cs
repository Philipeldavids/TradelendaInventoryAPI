using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Warehouse
    {
        public string WarehouseId { get; set; } = Guid.NewGuid().ToString();
        public string WarehouseName { get; set; }
       
        public string ContactPhone { get; set; }

        public Supplier ContactPerson { get; set; }
        
        public Stock Stock { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Status { get; set; }

    }
}
