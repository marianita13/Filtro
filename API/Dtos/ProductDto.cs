
using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int SellingQuantity { get; set; }
        public int SupplierPrice { get; set; }
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductLineId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
