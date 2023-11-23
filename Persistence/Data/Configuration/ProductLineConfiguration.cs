using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ProductLineConfiguration : IEntityTypeConfiguration<ProductLine>
    {
        public void Configure(EntityTypeBuilder<ProductLine> builder)
        {
            builder.ToTable("ProductLine");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.ProductLineName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DescriptionHTML);
            builder.Property(e => e.DescriptionText);
            builder.Property(e => e.Image);
        }
    }
}
