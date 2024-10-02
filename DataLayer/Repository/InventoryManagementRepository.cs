using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using Infracstructure.Models.DTO;
using Infracstructure.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<List<Brand>> GetBrand()
        {
            var res = _context.Brand.ToList();
            return res;
        }

        public async Task<bool> DeleteBrand(string id)
        {
            var res = _context.Brand.Where(x => x.BrandId == id).FirstOrDefault();
            _context.Brand.Remove(res);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditBrand(string Id, Brand brand)
        {
            var res = _context.Brand.Where(x => x.BrandId == Id).FirstOrDefault();

            res.BrandName = brand.BrandName;
            res.Status = brand.Status;
            res.Logo = brand.Logo;
            res.CreatedOn = brand.CreatedOn;

            _context.Brand.Update(res);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;

        }
        public async Task<bool> AddBrand(BrandDTO brand)
        {
            Brand brand1 = new Brand();
            brand1.BrandName = brand.BrandName;
            brand1.CreatedOn = DateTime.Now;
            brand1.Logo = brand.Logo;
            brand1.Status = brand.Status;

            _context.Brand.Add(brand1);

            if (_context.SaveChanges() > 0)
            {
                return true;
            };
            return false;

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

        public async Task<Category> GetCategoryById(string id)
        {
            var category = _context.Categories.Where(x=>x.CategoryId == id).FirstOrDefault();
            return category;
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

            var products = _context.Products
                .Include(x => x.Category)
                .Include(x=>x.Brand)
                .ToList();
            return products;
            
        }
        public async Task<IEnumerable<Product>> GetProductbyId(string Id)
        {
            var products = _context.Products.Where(x=>x.ProductId== Id)
                .Include(produpct => produpct.Category).ToList();

            return products;
        }
        public async Task<bool> AddProducts(Product product)
        {
                        
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
                //product.Brand = produt.Brand;
                product.Category = produt.Category;
                product.CategoryId = produt.CategoryId;
                product.CreatedBy = produt.CreatedBy;
                product.CreatedAt = product.CreatedAt;
                product.IsExpired = product.IsExpired;
                product.Price = produt.Price;
                product.Quantity = produt.Quantity;
                product.SKU = produt.SKU;
                product.Store = produt.Store;
                product.Warehouse = produt.Warehouse;
                product.ExpiredDate = produt.ExpiredDate;
                product.ManufacturedDate = produt.ManufacturedDate;
                product.Unit = produt.Unit;
                product.UnitCost = produt.UnitCost;

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

        public async Task<List<Product>> GetLOwStockProducts()
        {
            var product = _context.Products.Where(x=>x.Quantity <= 10)
                .Include(produpct=>produpct.Category)
                .ToList();

            if (product != null)
            {
                return product;
            }
            return null;

        }
        public async Task<List<Product>> GetNoStockProducts()
        {
            var product = _context.Products.Where(x => x.Quantity == 0)
                .Include(produpct => produpct.Category)
                .ToList();

            if (product != null)
            {
                return product;
            }
            return null;

        }

        public async Task<List<Product>> GetRecentProducts()
        {
            var product = _context.Products.Where(x => x.CreatedAt >= DateTime.UtcNow.AddDays(-10))
                .Include(produpct => produpct.Category)
                .ToList();
            if (product != null)
                return product;
            return null;
        }
        public async Task<List<Product>> GetExpiredProducts()
        {
            var product = _context.Products.Where(x => x.ExpiredDate <= DateTime.UtcNow && x.IsExpired == true)
                .Include(produpct => produpct.Category)
                .ToList();
            if (product != null)
                return product;
            return null;
        }
    }
}
