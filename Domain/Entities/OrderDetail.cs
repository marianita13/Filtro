
using System;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public int LineNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}