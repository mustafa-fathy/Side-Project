using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<CityPackage> CityPackages { get; set; }
        DbSet<CityTrip> CityTrips { get; set; }
        DbSet<Trip> Trips { get; set; }
    }
}
