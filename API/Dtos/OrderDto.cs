using System;
using Domain.Entities;

namespace Api.Dtos
{
    public class OrderDto
    
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateOnly ExpectedDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly OrderDate { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}