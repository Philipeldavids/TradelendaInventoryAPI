
using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
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

        public DbSet<Infracstructure.Models.UserManagement.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var permissions = new List<Permission>
            {
                new Permission { PermissionId = Guid.NewGuid(), PermissionName = Permissions.ViewUsers.ToString(), Description = "Can view users" },
                new Permission { PermissionId = Guid.NewGuid(), PermissionName = Permissions.EditUsers.ToString(), Description = "Can edit users" },
                new Permission { PermissionId = Guid.NewGuid(), PermissionName = Permissions.DeleteUsers.ToString(), Description = "Can delete users" },
                new Permission { PermissionId = Guid.NewGuid(), PermissionName = Permissions.CreateUsers.ToString(), Description = "Can create users" }
            };

            modelBuilder.Entity<Permission>().HasData(permissions);

            var adminRole = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = "Admin",
                Permissions = permissions // Assign all permissions to the Admin role
            };

            modelBuilder.Entity<Role>().HasData(adminRole);
        }
    }
}
