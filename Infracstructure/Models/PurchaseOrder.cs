using Infracstructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class PurchaseOrder
    {
        [Key]
        public string OrderId { get; set; } = Guid.NewGuid().ToString();
        public string CustomerId { get; set; } = Guid.NewGuid().ToString();
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderPlacedAt { get; set; }
        public DateTime? OrderFulfilledAt { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer {  get; set; }  


    }

    

    public class OrderItem
    {
        [Key]
        public string OrderItemId { get; set; } = Guid.NewGuid().ToString();
        public string PurchaseOrderId { get; set; } = Guid.NewGuid().ToString();

        
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }

        // Navigation property
        public PurchaseOrder Order { get; set; }
    }

}
