using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISalesService
    {
        Task AddNewSaleAsync(Sale sale);
        Task<List<Sale>> GetSalesListAsync();
        Task<Sale> GetSaleDetailAsync(string reference);
        Task EditSaleAsync(Sale sale);
        Task DeleteSaleAsync(string reference);
        Task<byte[]> DownloadPdfAsync(string reference);
        Task<byte[]> DownloadExcelAsync(string reference);
    }
}
