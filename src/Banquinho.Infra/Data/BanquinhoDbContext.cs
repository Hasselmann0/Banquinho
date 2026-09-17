using Banquinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Infra.Data
{
    public class BanquinhoDbContext : DbContext
    {
        public BanquinhoDbContext(DbContextOptions<BanquinhoDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BanquinhoDbContext).Assembly);
        }


    }
}
