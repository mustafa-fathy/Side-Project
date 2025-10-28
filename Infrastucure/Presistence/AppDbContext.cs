using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Presistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<CityTrip> CityTrips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<CityPackage> CityPackages { get; set; }
       
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




           builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}


