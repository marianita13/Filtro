using System;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Comments { get; set; }
        public DateOnly ExpectedDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly OrderDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}