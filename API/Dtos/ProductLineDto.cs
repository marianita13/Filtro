
using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class ProductLineDto
    {
        public string ProductLineName { get; set; }
        public string DescriptionText { get; set; }
        public int Id { get; set; }
        public string DescriptionHTML { get; set; }
        public string Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}