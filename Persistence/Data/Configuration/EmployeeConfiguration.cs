using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.ManagerCode).HasMaxLength(50);
            builder.Property(e => e.Extention).HasMaxLength(50);

            builder.HasOne(e => e.Person)
            .WithMany(e => e.Employees)
            .HasForeignKey(e =>e.PersonId);

            builder.HasOne(e => e.PostalCode)
            .WithMany(e => e.Employees)
            .HasForeignKey(e =>e.PostalCodeId);

            builder.HasOne(e => e.Office)
            .WithMany(e => e.Employees)
            .HasForeignKey(e =>e.OfficeId);
        }
    }
}