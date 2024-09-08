using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISalesReturnService
    {
        Task<bool> AddNewSalesReturnAsync(SalesReturn salesReturn);
        Task<List<SalesReturn>> GetSalesReturnListAsync();
        Task<bool> EditSalesReturnAsync(SalesReturn salesReturn);
        Task<bool> DeleteSalesReturnAsync(string reference);
    }
}
