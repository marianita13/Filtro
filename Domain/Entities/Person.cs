
using System;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name{ get; set; }
        public string LastName1{ get; set; }
        public string LastName2{ get; set; }
        public string Email { get; set; }
        public PersonType PersonType { get; set; }
        public int PersonTypeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}