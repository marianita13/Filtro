using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class FiltroGardenContext : DbContext
    {
        public FiltroGardenContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MethodPayment> MethodPayments { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}