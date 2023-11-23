using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Comments).IsRequired().HasMaxLength(50);
            builder.Property(e => e.OrderDate).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DeliveryDate).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ExpectedDate).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.Client)
            .WithMany(e => e.Orders)
            .HasForeignKey(e =>e.ClientId);

            builder.HasOne(e => e.Status)
            .WithMany(e => e.Orders)
            .HasForeignKey(e =>e.StatusId);
        }
    }
}