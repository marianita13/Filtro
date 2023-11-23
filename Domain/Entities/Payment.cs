using System;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int Total { get; set; }
        public string TransactionId { get; set; }
        public DateOnly PaymentDate { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public MethodPayment MethodPayment { get; set; }
        public int MethodPaymentId { get; set; }
    }
}