using HelmesCustomerManager.Domain.Entities;

namespace HelmesCustomerManager.Domain.RepositoryInterfaces;

public interface ICustomerRepo
{
    IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds);        

    Task AddCustomerAsync(Customer customerModel);

    Task UpdateCustomer(Customer updatedCustomer);
}