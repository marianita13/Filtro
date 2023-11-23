using System;

namespace Domain.Entities
{
    public class Office : BaseEntity
    {
        public int Phone { get; set; }
        public string AdressLine { get; set; }
        public string AdressLine2 { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}