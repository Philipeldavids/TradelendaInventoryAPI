using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Warehouse
    {
        [Key]
        public string WarehouseId { get; set; } 
        [Required]
        public string WarehouseName { get; set; }

        [Required]
        public string? ContactPhone { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        public Supplier? supplier { get; set; } = new Supplier();
        public Stock? Stock { get; set; } = new Stock();

        public List<Store>? Stores { get; set; } = new List<Store>();

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? State { get; set; }
        public string? City { get; set; }

        public string? ZipCode { get; set; }
        public string? Country { get; set; }

        public int? Quantity { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;

    }
}
