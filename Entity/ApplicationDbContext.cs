using System;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Role> RolesRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "Admin";
            string userRoleName = "User";
            string superAdminRoleName = "SuperAdmin";
            Role adminRole = new Role { Name = adminRoleName, NormalizedName = adminRoleName.ToUpper(), IsPublish = true };
            Role userRole = new Role { Name = userRoleName, NormalizedName = userRoleName.ToUpper(), IsPublish  = true};
            Role superAdminRole = new Role { Name = superAdminRoleName, NormalizedName = superAdminRoleName.ToUpper(), IsPublish = false};

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, superAdminRole });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
