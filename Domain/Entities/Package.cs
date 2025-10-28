using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Package : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToCityId { get; set; }
        
        public virtual City ToCity { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [Precision(18, 2)]
        public decimal ChildPrice { get; set; }
        public int Guests { get; set; }
        public int RemainingGuests { get; set; }
        public string AboutExploreTour { get; set; }
        
        public int FromCityId { get; set; }
        public virtual City City { get; set; }
       
        public ICollection<CityPackage> CityPackages { get; set; }


    }
}
