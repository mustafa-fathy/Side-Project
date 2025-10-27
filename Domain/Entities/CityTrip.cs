using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CityTrip : BaseEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int TripId { get; set; }
        public virtual City Cities { get; set; }
        public virtual Trip Trips { get; set; }
    }
}
