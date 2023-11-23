using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PostalCodeConfiguration : IEntityTypeConfiguration<PostalCode>
    {
        public void Configure(EntityTypeBuilder<PostalCode> builder)
        {
            builder.ToTable("PostalCode");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.PóstalCodeNumber).IsRequired().HasMaxLength(50);
        }
    }
}
