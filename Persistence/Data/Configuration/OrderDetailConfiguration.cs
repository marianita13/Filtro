using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Quantity).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LineNumber).IsRequired().HasMaxLength(50);
            builder.Property(e => e.UnitPrice).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.Order)
            .WithMany(e => e.OrderDetails)
            .HasForeignKey(e =>e.OrderId);

            builder.HasOne(e => e.Product)
            .WithMany(e => e.OrderDetails)
            .HasForeignKey(e =>e.ProductId);
        }
    }
}
