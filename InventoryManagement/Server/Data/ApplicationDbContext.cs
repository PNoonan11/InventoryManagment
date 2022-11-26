using Duende.IdentityServer.EntityFramework.Options;
using InventoryManagement.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;


namespace InventoryManagement.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
       
        public DbSet<ProductInLocations> LocationOfProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductInLocations>()
                    .HasKey(po => new { po.ProductEntityId, po.LocationEntityId });
            modelBuilder.Entity<ProductInLocations>()
                    .HasOne(p => p.Product)
                    .WithMany(pc => pc.ListOfProducts)
                    .HasForeignKey(p => p.ProductEntityId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductInLocations>()
                    .HasOne(p => p.Location)
                    .WithMany(pc => pc.ListOfLocations)
                    .HasForeignKey(c => c.LocationEntityId)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}