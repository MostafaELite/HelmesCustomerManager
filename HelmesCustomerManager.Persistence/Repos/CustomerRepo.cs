using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HelmesCustomerManager.Persistence.Repos;

public class CustomerRepo(HelmesContext _context) : ICustomerRepo
{
    public IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds)
    {
        var query = customerIds?.Any() != true
            ? _context.Customer
            : _context.Customer.Where(customer => customerIds.Contains(customer.Id));

        var customers = query
            .Include(customer => customer.Sections)
            .ToArray();
        return customers;
    }

    public void AddCustomer(Customer customer)
    {
        _context.Customer.Add(customer);
        foreach (var section in customer.Sections)
        {
            //TODO: check if already tracked
            var updatedSection = _context.Entry(section);
            updatedSection.State = EntityState.Unchanged;
        }
        _context.SaveChanges();
    }
}
