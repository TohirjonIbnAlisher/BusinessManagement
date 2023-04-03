using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Domain.Entities
{
    public class LegalPersons
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long INN { get; set; }
        public string IndustryType { get; set; }
        public LegalEntityType LegalEntityType { get; set; }
        public Guid AddressId { get; set; }
        public Addresses Address { get; set; }
        public ICollection<Employees>? Employees { get; set; }

    }

}
