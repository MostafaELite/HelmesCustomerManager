using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;

namespace HelmesCustomerManager.Domain.Services;

public interface ICustomerService
{
    void AddCustomer(CreateCustomerModel customerModel);

    IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerId = null);
}
