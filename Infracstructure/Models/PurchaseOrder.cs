using Infracstructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class PurchaseOrder
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderPlacedAt { get; set; }
        public DateTime? OrderFulfilledAt { get; set; }
        public decimal TotalAmount { get; set; }

       public Customer Customer {  get; set; }  


    }

    

    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }

        // Navigation property
        public PurchaseOrder Order { get; set; }
    }

}
