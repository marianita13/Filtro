using System;

namespace Api.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string TransactionId { get; set; }
        public DateOnly PaymentDate { get; set; }
        public int ClientId { get; set; }
        public int MethodPaymentId { get; set; }
    }
}