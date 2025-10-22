using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Presistence
{
    public class AppDbContext : DbContext , IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
          public DbSet<City> Cities { get; set; }
          public DbSet<Country> Countries { get; set; }
          public DbSet<Company> Companies { get; set; }
          public DbSet<Package> Packages { get; set; }
          public DbSet<CityPackage> CityPackages { get; set; }
          public DbSet<CityTrip> CityTrips { get; set; }
          public DbSet<Trip> Trips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Trip>()
                .Property(P => P.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<CityPackage>()
                .HasOne(cp => cp.Package)
                .WithMany(p => p.CityPackages)
                .HasForeignKey(cp => cp.PackageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
