using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Trip :BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int Guests { get; set; }
        public TimeSpan TripHours { get; set; }
        public int PackageId { get; set; }
        [Precision(18, 2)]
        public decimal ChildPrice { get; set; }
        public int RemainingGuests { get; set; }
        public int FromCityId { get; set; }
        public virtual City City { get; set; }

    }
}
