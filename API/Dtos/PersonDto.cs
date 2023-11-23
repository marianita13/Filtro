
using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string LastName1{ get; set; }
        public string LastName2{ get; set; }
        public string Email { get; set; }
        public int PersonTypeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}