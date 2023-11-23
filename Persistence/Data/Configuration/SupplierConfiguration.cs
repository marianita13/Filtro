using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Fax).IsRequired().HasMaxLength(50);
        }
    }
}
