

using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}