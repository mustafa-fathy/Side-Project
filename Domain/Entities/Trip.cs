using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        public decimal Price { get; set; }
        public int Guests { get; set; }
        public TimeSpan TripHours { get; set; }
        public int PackageId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        [Precision(18, 2)]
        public decimal ChildPrice { get; set; }
        public int RemainingGuests { get; set; }
        public int FromCityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<CityTrip> ToCity { get; set; }
    }
}
