using HelmesCustomerManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace HelmesCustomerManager.Persistence;

public class EntityConfig
{
    internal static void ConfigureCustomers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(sectorConfig =>
        {
            sectorConfig.HasMany(customer => customer.Sections)
                .WithMany();
        });
    }

    internal static void ConfigureSectors(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sector>(sectorConfig =>
        {
            sectorConfig.HasMany(sector => sector.SubSectors)
                .WithOne()
                .HasForeignKey(subSector => subSector.ParentSectorId)
                .OnDelete(DeleteBehavior.Cascade);

            var seedingSectors = GetSeedingSectors();
            sectorConfig.HasData(seedingSectors);
        });
    }


    private static IEnumerable<Sector> GetSeedingSectors()
    {
        var jsonData = File.ReadAllText("sectors.json");
        var sectors = JsonSerializer.Deserialize<IEnumerable<Sector>>(jsonData);
        return sectors;
    }
}