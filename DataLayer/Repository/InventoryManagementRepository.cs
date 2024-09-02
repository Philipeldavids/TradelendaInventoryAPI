using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using Infracstructure.Models.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class InventoryManagementRepository : IInventoryManagementRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryManagementRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<bool> AddCategory(CategoryDTO category)
        {
            Category category1 = new Category();
            category1.CategoryName = category.CategoryName;
            category1.CategorySLug = category.CategoryName.ToLower();
            category1.CreatedOn = DateTime.Now;
            category1.Status = true; 

            _context.Categories.Add(category1);
            if (_context.SaveChanges() > 0)
            {
                return true;
            };
            return false;
        }

        public async Task<IEnumerable<Category>> GetGategoryList()
        {
            var categories = _context.Categories.ToList();

            return categories;
        }

        public async Task<bool> EditCategory(CategoryDTO category)
        {
            var category1 = _context.Categories.Where(x=>x.CategoryName == category.CategoryName).FirstOrDefault();
            
            category1.CategoryName = category.CategoryName;
            category1.CategorySLug = category.CategoryName.ToLower();
            category1.Status = category.Status;
            
            _context.Categories.Update(category1);
            if(_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
          
        }

        public async Task<bool> DeleteCategory(string CategoryId)
        {
            var category = _context.Categories.Where(x=> x.CategoryId == CategoryId).FirstOrDefault();

            _context.Categories.Remove(category);
            if(_context.SaveChanges() > 0)
            {
                return true;
            }
            return false; 
        }
        public async Task<IEnumerable<Product>> GetallProducts()
        {

            var products = _context.Products.ToList();
            return products;
            
        }
        public async Task<IEnumerable<Product>> GetProductbyId(string Id)
        {
            var products = _context.Products.Where(x=>x.ProductId== Id).ToList();

            return products;
        }
        public async Task<bool> AddProducts(Product product)
        {
            var category = _context.Categories.Where(x=>x.CategoryId == product.CategoryId).FirstOrDefault();

            if(category == null)
            {
                category = new Category { CategoryId = product.CategoryId, CategoryName = "New Category", CategorySLug = "new category" };
                _context.Categories.Add(category);
                _context.SaveChanges(); // Save the new category
            }
            product.Category = category;
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> EditProduct(Product produt, string Id)
        {
            var product = _context.Products.Where(x=> x.ProductId == Id).FirstOrDefault();
            if(product != null)
            {
                product.ProductName = produt.ProductName;
                product.ProductDescription = produt.ProductDescription;
                product.Barcode = produt.Barcode;
                product.Brand = produt.Brand;
                product.Category = produt.Category;
                product.CategoryId = produt.CategoryId;
                product.CreatedBy = produt.CreatedBy;
                product.CreatedAt = product.CreatedAt;
                product.IsExpired = product.IsExpired;
                product.Price = produt.Price;
                product.Quantity = produt.Quantity;
                product.SKU = produt.SKU;
                product.Unit = produt.Unit;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(string Id)
        {
            var product = _context.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
