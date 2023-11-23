
using System;

namespace Domain.Entities
{
    public class ProductLine : BaseEntity
    {
        public string ProductLineName { get; set; }
        public string DescriptionText { get; set; }
        public string DescriptionHTML { get; set; }
        public string Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}