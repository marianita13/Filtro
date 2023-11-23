using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Phone).IsRequired().HasMaxLength(50);
            builder.Property(e => e.OfficeCode).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AdressLine).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AdressLine2).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.City)
            .WithMany(e => e.Offices)
            .HasForeignKey(e =>e.CityId);
        }
    }
}