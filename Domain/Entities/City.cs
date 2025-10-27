namespace Domain.Entities
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<CityTrip> CityTrips { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<CityPackage> CityPackges { get; set; }


    }
}
