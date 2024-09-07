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
        Task AddNewSalesReturnAsync(SalesReturn salesReturn);
        Task<List<SalesReturn>> GetSalesReturnListAsync();
        Task EditSalesReturnAsync(SalesReturn salesReturn);
        Task DeleteSalesReturnAsync(string reference);
    }
}
