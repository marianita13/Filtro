
using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class PostalCodeDto
    {
        public int PóstalCodeNumber { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
        public int Id { get; set; }
    }
}