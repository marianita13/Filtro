using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName1).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName2).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.PersonType)
            .WithMany(e => e.Persons)
            .HasForeignKey(e =>e.PersonTypeId);

        }
    }
}
