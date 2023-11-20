using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HelmesCustomerManager.Persistence.Repos;

public class CustomerRepo(HelmesContext context) : ICustomerRepo
{
    public IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds)
    {
        var query = customerIds?.Any() != true
            ? context.Customer
            : context.Customer.Where(customer => customerIds.Contains(customer.Id));

        var customers = query
            .Include(customer => customer.Sectors)
            .AsNoTracking()
            .ToArray();
        return customers;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        context.Customer.Add(customer);
        UntrackSections(customer.Sectors);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCustomer(Customer updatedCustomer)
    {
        var existingCustomer = context.Customer
            .Include(c => c.Sectors)
            .FirstOrDefault(c => c.Id == updatedCustomer.Id) ??
                               throw new Exception($"Can't find a customer with the Id {updatedCustomer.Id}");

        existingCustomer.Name = updatedCustomer.Name;

        var selectedSectorIds = updatedCustomer.Sectors.Select(sector => sector.Id);
        var existingSectorIds = existingCustomer.Sectors.Select(sector => sector.Id);

        var addedSectorsIds = selectedSectorIds.Except(existingSectorIds).ToHashSet();
        var removedSectorIds = existingCustomer.Sectors.Where(sector => !selectedSectorIds.Contains(sector.Id));

        foreach (var removedSector in removedSectorIds)
            existingCustomer.Sectors.Remove(removedSector);

        foreach (var sectorId in addedSectorsIds)
            existingCustomer.Sectors.Add(new Sector { Id = sectorId, Name = string.Empty});

        UntrackSections(updatedCustomer.Sectors);
        await context.SaveChangesAsync();
    }

    private void UntrackSections(IEnumerable<Sector> sectors)
    {
        foreach (var sector in sectors)
        {
            var alreadyTracked = context.ChangeTracker.Entries<Sector>().FirstOrDefault(tracked => tracked.Entity.Id == sector.Id);
            if (alreadyTracked != null)
            {
                alreadyTracked.State = EntityState.Unchanged;
                continue;
            }
            context.Entry(sector).State = EntityState.Unchanged;
        }
    }
}
