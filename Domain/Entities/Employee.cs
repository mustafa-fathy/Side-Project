using Domain.Entities.Auth;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Id { get; set; }
        public decimal ServiceFees { get; set; }
        public int AgentCode { get; set; }
        public DateTime LastLogin { get; set; }
        public decimal Target { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
