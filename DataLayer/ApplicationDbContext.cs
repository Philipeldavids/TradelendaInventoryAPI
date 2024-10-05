
using Infracstructure.Models;
using Infracstructure.Models.Enums;
using Infracstructure.Models.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }


       

       // public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            



            // Define composite primary key using HasKey
            modelBuilder.Entity<User>()
               .HasKey(c => c.UserId);
            modelBuilder.Entity<User>().HasOne(c => c.UserProfil);
           
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);// Each Product has one Category
                                         // Each Category can have many Products
            modelBuilder.Entity<Product>()
        .HasOne(p => p.Brand);
            modelBuilder.Entity<Purchase>().HasOne(p => p.Supplier);

            modelBuilder.Entity<OrderItem>().HasKey(p => p.OrderItemId);

            modelBuilder.Entity<Customer>().HasOne(p => p.PurchaseOrders);
            modelBuilder.Entity<PurchaseOrder>().HasKey(p=>p.OrderId);  
            
            modelBuilder.Entity<Supplier>().HasKey(p=>p.SupplierID);

          
            modelBuilder.Entity<Stock>().HasKey(p=> p.StockId);
            modelBuilder.Entity<Warehouse>().HasOne(p => p.Stock);
            modelBuilder.Entity<Warehouse>().HasOne(p=>p.supplier);
             modelBuilder.Entity<Store>().HasKey(p=>p.StoreId);

            modelBuilder.Entity<Payment>().HasKey(p => p.Reference);    
            modelBuilder.Entity<Sale>().HasKey(p => p.Reference);
            
            modelBuilder.Entity<SalesReturn>().HasKey(p=>p.Reference);
            modelBuilder.Entity<Brand>().HasKey(p=>p.BrandId);
            modelBuilder.Entity<SalesReport>().HasKey(p=>p.SalesReportId);
            modelBuilder.Entity<PurchaseReport>().HasKey(p=>p.PurcahseReportId);    
           
            // Other configurations can go here
        }
        //public DbSet<AppUser> Users { get; set; }

        public DbSet<PurchaseReport> PurchaseReports { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<PurchaseOrder> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SalesReturn> SalesReturns { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }

    }
}
