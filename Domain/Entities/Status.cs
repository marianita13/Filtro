
using System;

namespace Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}