using System;

namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime CreationDate { get; set; }
        public int CountryId { get; set; }
        public string CreatedById { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public Int32 Code { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}

