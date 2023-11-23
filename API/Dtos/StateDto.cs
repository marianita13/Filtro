using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}