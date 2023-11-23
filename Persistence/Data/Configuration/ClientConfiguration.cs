using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Entity");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Phone).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Fax).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LineAdress).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LineAdress2).IsRequired().HasMaxLength(50);
            builder.Property(e => e.CreditLimit).IsRequired().HasMaxLength(50);

            builder.HasOne(e => e.Employee)
            .WithMany(e => e.Clients)
            .HasForeignKey(e =>e.EmployeeId);

            builder.HasOne(e => e.PostalCode)
            .WithMany(e => e.Clients)
            .HasForeignKey(e =>e.PostalCodeId);

            builder.HasOne(e => e.person)
            .WithMany(e => e.Clients)
            .HasForeignKey(e =>e.PersonId);
        }
    }
}