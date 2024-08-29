using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
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

        public async Task<List<Product>> GetallProducts()
        {
            var products = _context.Products.ToList();
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
                product.Brand = produt.Brand;
                product.Category = produt.Category;
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
