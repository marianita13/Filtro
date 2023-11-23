using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Total).IsRequired().HasMaxLength(50);
            builder.Property(e => e.TransactionId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PaymentDate).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.Client)
            .WithMany(e => e.Payments)
            .HasForeignKey(e =>e.ClientId);

            builder.HasOne(e => e.MethodPayment)
            .WithMany(e => e.Payments)
            .HasForeignKey(e =>e.MethodPaymentId);
        }
    }
}
