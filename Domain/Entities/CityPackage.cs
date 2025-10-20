using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CityPackage
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
