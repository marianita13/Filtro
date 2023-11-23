
using System;

namespace Domain.Entities
{
    public class PostalCode : BaseEntity
    {
        public int PóstalCodeNumber { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}