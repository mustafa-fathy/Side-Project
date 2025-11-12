using System;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public byte Code { get; set; }
        public string? Icon { get; set; }
        public virtual ICollection<City> Cities { get; set; } 
    }
}

