
using Infracstructure.Models;
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
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        

       // public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var permissions = new List<Permission>
            //{
            //    new Permission { PermissionId = Guid.NewGuid().ToString(), PermissionName = Permissions.ViewUsers.ToString(), Description = "Can view users" },
            //    new Permission { PermissionId = Guid.NewGuid().ToString(), PermissionName = Permissions.EditUsers.ToString(), Description = "Can edit users" },
            //    new Permission { PermissionId = Guid.NewGuid().ToString(), PermissionName = Permissions.DeleteUsers.ToString(), Description = "Can delete users" },
            //    new Permission { PermissionId = Guid.NewGuid().ToString(), PermissionName = Permissions.CreateUsers.ToString(), Description = "Can create users" }
            //};

           
            
            //modelBuilder.Entity<Permission>().HasOne(p=>p.Roles)
            //    .WithMany(p=>p.Permissions)
            //    .HasForeignKey(p=>p.PermissionId);


            //modelBuilder.Entity<Role>().HasKey(p => p.RoleId);


            // Define composite primary key using HasKey
            modelBuilder.Entity<User>()
               .HasKey(c=>c.UserId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);// Each Product has one Category
                                         // Each Category can have many Products
            modelBuilder.Entity<OrderItem>().HasKey(p => p.OrderItemId);
                

            modelBuilder.Entity<OrderItem>().HasKey(p => p.OrderItemId);

            modelBuilder.Entity<Customer>().HasOne(p => p.PurchaseOrders);
            modelBuilder.Entity<PurchaseOrder>().HasKey(p=>p.OrderId);                

          
            modelBuilder.Entity<Stock>().HasKey(p=> p.StockId);
            modelBuilder.Entity<Warehouse>().HasOne(p => p.Stock);

            modelBuilder.Entity<Payment>().HasKey(p => p.Reference);    
            modelBuilder.Entity<Sale>().HasKey(p => p.Reference);

            modelBuilder.Entity<SalesReturn>().HasKey(p=>p.Reference);
            // Other configurations can go here
        }
        //public DbSet<AppUser> Users { get; set; }

        public DbSet<User> Users { get; set; }       
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
