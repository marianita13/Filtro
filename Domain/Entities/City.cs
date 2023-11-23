using System;

namespace Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
        public ICollection<Office> Offices { get; set; }
    }
}