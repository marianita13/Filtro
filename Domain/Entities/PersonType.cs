using System;

namespace Domain.Entities
{
    public class PersonType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> Persons{ get; set; }
    }
}