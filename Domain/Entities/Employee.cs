using System;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int ManagerCode { get; set; }
        public string Extention { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        public PostalCode PostalCode { get; set; }
        public int PostalCodeId { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}