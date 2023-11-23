
using System;

namespace Api.Dtos
{
    public class OrderDetailDto
    {
        public int Quantity { get; set; }
        public int LineNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
}