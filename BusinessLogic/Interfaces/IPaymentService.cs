using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> CreatePaymentAsync(Payment payment);
        Task<List<Payment>> GetPaymentsAsync();
        Task<bool> DeletePaymentAsync(string reference);
    }
}
