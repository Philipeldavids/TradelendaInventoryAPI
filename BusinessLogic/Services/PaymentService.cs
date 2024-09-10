using BusinessLogic.Interfaces;
using DataLayer;
using Infracstructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePaymentAsync(Payment payment)
        {
             _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return _context.Payments.ToList();
        }

        public async Task<bool> DeletePaymentAsync(string reference)
        {
            var payment = _context.Payments.Where(p => p.Reference == reference).FirstOrDefault();
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
