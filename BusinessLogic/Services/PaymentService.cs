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

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task DeletePaymentAsync(string reference)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Reference == reference);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
