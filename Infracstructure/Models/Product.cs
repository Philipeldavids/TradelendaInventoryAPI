using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Infracstructure.Models.Enums;

namespace Infracstructure.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }  
        public string? Store { get; set; }
        public string? Warehouse{ get; set; }

        public Category? Category { get; set; } = new Category();

        public string? CategoryId { get; set; }      

        public Brand? Brand { get; set; } = new Brand();
        public string? BrandId { get; set; }
        public string? Barcode { get; set; }
        public decimal Price { get; set; }
        public bool IsExpired { get; set; }
        public string? Unit { get; set; }
        public int Quantity { get; set; }
        public string? CreatedBy { get; set; }

      
        public string? SKU { get; set; }
       
       public string? ProductImageUrl { get; set; }  

        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        
        public decimal UnitCost { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       

    }
}
