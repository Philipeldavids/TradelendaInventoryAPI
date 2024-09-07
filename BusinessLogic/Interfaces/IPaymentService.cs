﻿using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task CreatePaymentAsync(Payment payment);
        Task<List<Payment>> GetPaymentsAsync();
        Task DeletePaymentAsync(string reference);
    }
}
