
using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}