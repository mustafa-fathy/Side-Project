namespace Domain.Entities
{
    public class Company :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
