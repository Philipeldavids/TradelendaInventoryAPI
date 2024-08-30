
using Infracstructure.Models;
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

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<PurchaseOrder> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary key using HasKey
            modelBuilder.Entity<AppUser>()
                .HasNoKey();

            modelBuilder.Entity<Product>()
                .HasOne(p=> p.Category);// Each Product has one Category
                                    // Each Category can have many Products
            

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(p => p.CustomerId);
            
            modelBuilder.Entity<Stock>().HasNoKey();

            // Other configurations can go here
        }
    }
}
