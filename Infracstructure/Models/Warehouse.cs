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
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public string? ContactPhone { get; set; }

        public Supplier supplier { get; set; } = new Supplier();

        public Stock Stock { get; set; } = new Stock();

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Status { get; set; }

    }
}
