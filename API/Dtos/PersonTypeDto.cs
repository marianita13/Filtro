using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class PersonTypeDto
    {
        public string Name { get; set; }
        public ICollection<Person> Persons{ get; set; }
        public int Id { get; set; }
    }

}