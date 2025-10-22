namespace Domain.Entities
{
    public class CityTrip:BaseEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
