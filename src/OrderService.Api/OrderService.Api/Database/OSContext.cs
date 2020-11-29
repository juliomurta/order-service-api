using Microsoft.EntityFrameworkCore;
using OrderService.Api.Database.Configurations;
using OrderService.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Database
{
    public class OSContext : DbContext
    {
        public OSContext(DbContextOptions<OSContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
