
using System;

namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}