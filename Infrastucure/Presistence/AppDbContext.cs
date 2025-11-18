using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Auth;
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

        #region Auth
        public DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region Side-Proj Entites
        public DbSet<Country> Countries { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<CityTrip> CityTrips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<CityPackage> CityPackages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




           builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}


