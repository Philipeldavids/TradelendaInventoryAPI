using Infracstructure.Models;
using Infracstructure.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IInventoryManagementRepository
    {
        Task<bool> AddCategory(CategoryDTO category);
        Task<List<Category>> GetGategoryList();
        Task<bool> EditCategory(CategoryDTO category);
        Task<bool> DeleteCategory(string CategoryId);
        Task<List<Product>> GetallProducts();
        Task<bool> AddProducts(Product product);
        Task<bool> EditProduct(Product produt, string Id);
        Task<bool> DeleteProduct(string Id);

        Task<List<Product>> GetProductbyId(string Id);
    }
}
