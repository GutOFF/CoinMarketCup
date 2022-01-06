using System;
using Entity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<SettingCryptocurrency> SettingCryptocurrency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "Admin";
            string userRoleName = "User";
            string superAdminRoleName = "SuperAdmin";
            Role adminRole = new Role { Name = adminRoleName, NormalizedName = adminRoleName.ToUpper(), IsPublish = true };
            Role userRole = new Role { Name = userRoleName, NormalizedName = userRoleName.ToUpper(), IsPublish  = true};
            Role superAdminRole = new Role { Name = superAdminRoleName, NormalizedName = superAdminRoleName.ToUpper(), IsPublish = false};

            modelBuilder.Entity<Role>()
                .HasData(new Role[] { adminRole, userRole, superAdminRole });

            modelBuilder.Entity<SettingCryptocurrency>()
                .HasData(new SettingCryptocurrency()
                {
                    Id = 1,
                    ApiKey = "10c2408c-f3fd-4c1e-801e-b97ba3bba899", 
                    ExpiryDateExpired = 5,
                    LastUpdateDate = DateTime.UtcNow, 
                    Limit = 2500, 
                    MaxCountMetadata = 1000,
                    FiatCurrency = "USD"
                });

            modelBuilder.Entity<Cryptocurrency>()
                .Property(b => b.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Cryptocurrency>()
                .Property(b => b.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Cryptocurrency>()
                .HasIndex(w => w.CoinMarketCupId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}
