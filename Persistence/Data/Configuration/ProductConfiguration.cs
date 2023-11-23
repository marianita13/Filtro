using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Dimensions).HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(50);
            builder.Property(e => e.StockQuantity).HasMaxLength(50);
            builder.Property(e => e.SellingQuantity).HasMaxLength(50);
            builder.Property(e => e.SupplierPrice).HasMaxLength(50);

            builder.HasOne(e => e.Supplier)
            .WithMany(e => e.Products)
            .HasForeignKey(e =>e.SupplierId);

            builder.HasOne(e => e.ProductLine)
            .WithMany(e => e.Products)
            .HasForeignKey(e =>e.ProductLineId);
        }
    }
}
