using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        public Supplier Supplier { get; set; } = new Supplier();

        public DateTime PurchaseDate { get; set; }

        public string ProductName { get; set; }

        public string Reference { get; set; }

        public string Status { get; set; }

        public decimal Paid { get; set; }

        public decimal Due { get; set; }

        public string CreatedBy { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public decimal Discount { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal TaxAmount
        {
            get
            {
                return (TotalCost - Discount) * (TaxPercentage / 100);
            }
        }

        public decimal TotalCost
        {
            get
            {
                return Products?.Sum(p => p.UnitCost) ?? 0;
            }
        }

        public decimal Shipping { get; set; }
    }
}
