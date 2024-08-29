using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IInventoryManagementRepository
    {
        Task<List<Product>> GetallProducts();
        Task<bool> AddProducts(Product product);
        Task<bool> EditProduct(Product produt, string Id);
        Task<bool> DeleteProduct(string Id);
    }
}
