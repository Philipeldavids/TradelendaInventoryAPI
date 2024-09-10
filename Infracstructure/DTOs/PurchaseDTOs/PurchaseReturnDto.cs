using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.PurchaseDTOs
{
    public class PurchaseReturnDto
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public decimal ReturnAmount { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}
