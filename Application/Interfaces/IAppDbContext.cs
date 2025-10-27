using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<CityTrip> CityTrips { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<CityPackage> CityPackages { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<Airport> Airports { get; set; }
    }
}
