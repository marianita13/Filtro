using System;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public int Phone { get; set; }
        public int Fax { get; set; }
        public string LineAdress {get; set; }
        public string LineAdress2 {get; set; }
        public int CreditLimit { get; set; }
        public Person person { get; set; }
        public int PersonId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public PostalCode PostalCode { get; set; }
        public int PostalCodeId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}