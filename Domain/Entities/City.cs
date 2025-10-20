using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<CityPackage> CityPackages { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<CityTrip> CityTrips { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
