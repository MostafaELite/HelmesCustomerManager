using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.RepositoryInterfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HelmesCustomerManager.Persistence.Repos;

public class CustomerRepo(HelmesContext context) : ICustomerRepo
{
    public HelmesContext Context { get; } = context;

    public IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds)
    {
        var query = customerIds?.Any() != true
            ? Context.Customer
            : Context.Customer.Where(customer => customerIds.Contains(customer.Id));

        var customers = query
            .Include(customer => customer.Sectors)
            .AsNoTracking()
            .ToArray();
        return customers;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        Context.Customer.Add(customer);
        UntrackSections(customer.Sectors);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateCustomer(Customer updatedCustomer)
    {
        var existingCustomer = context.Customer
            .Include(c => c.Sectors)
            .FirstOrDefault(c => c.Id == updatedCustomer.Id);

        existingCustomer.Name = updatedCustomer.Name;

        var selectedSectorIds = updatedCustomer.Sectors.Select(sector => sector.Id).ToHashSet();
        var existingSectorIds = existingCustomer.Sectors.Select(sector => sector.Id);

        var addedSectorsIds = selectedSectorIds.Except(existingSectorIds);

        //TODO: use join
        foreach (var existingSector in existingCustomer.Sectors)
            if (!selectedSectorIds.Contains(existingSector.Id))
                existingCustomer.Sectors.Remove(existingSector);

        foreach (var sectorId in addedSectorsIds)
            existingCustomer.Sectors.Add(new Sector { Id = sectorId });

        UntrackSections(updatedCustomer.Sectors);
        await Context.SaveChangesAsync();
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
            Context.Entry(sector).State = EntityState.Unchanged;
        }
    }
}
