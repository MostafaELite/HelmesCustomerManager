using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.RepositoryInterfaces;
using Mapster;

namespace HelmesCustomerManager.Domain.Services;

public class CustomerService(ICustomerRepo customerRepo) : ICustomerService
{
    //Might argue about which model to accept here, domain's or outer layer's
    public void AddCustomer(CreateCustomerModel customerModel)
    {
        var customer = customerModel.Adapt<Customer>();
        customer.GenerateId();
        customerRepo.AddCustomer(customer);
    }

    public IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerId) => customerRepo.GetCustomers(customerId);
}
