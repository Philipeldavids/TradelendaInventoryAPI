using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public Supplier Supplier { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string ProductName { get; set; }

        public string Reference { get; set; }

        public string Status { get; set; }

        public decimal Paid { get; set; }

        public decimal Due { get; set; }

        public string CreatedBy { get; set; }

        public List<Product> Products { get; set; }

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
                return Products?.Sum(p => p.Price) ?? 0;
            }
        }

        public decimal Shipping { get; set; }
    }
}
