using HelmesCustomerManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelmesCustomerManager.Persistence
{
    public class HelmesContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityConfig.ConfigureCustomers(modelBuilder);
            EntityConfig.ConfigureSectors(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseInMemoryDatabase("HelmesCustomers_MostafaAhmed");
    }
}
