using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;

namespace HelmesCustomerManager.Domain.Services;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerId = null);

    Task<Customer> AddCustomer(CustomerViewModel customerModel);

    Task UpdateCustomer(Guid customerId, CustomerViewModel updatedPayload);
}
