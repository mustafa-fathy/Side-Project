using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Presistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<CityTrip> CityTrips { get; set; }
        public DbSet<CityPackage> CityPackages { get; set; }
        public DbSet<Package> Packages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
    .HasOne(p => p.City)
    .WithMany(c => c.Packages)
    .HasForeignKey(p => p.FromCityId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Package>()
    .HasOne(p => p.ToCity)
    .WithMany(c => c.Packages)
    .HasForeignKey(p => p.ToCityId)
    .OnDelete(DeleteBehavior.Restrict);
        }

    }
    }


