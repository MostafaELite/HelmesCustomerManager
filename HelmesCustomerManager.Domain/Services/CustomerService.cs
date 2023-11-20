using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;
using HelmesCustomerManager.Domain.RepositoryInterfaces;
using Mapster;

namespace HelmesCustomerManager.Domain.Services;

public class CustomerService(ICustomerRepo customerRepo) : ICustomerService
{
    public IEnumerable<Customer> GetCustomers(IEnumerable<Guid>? customerId) => customerRepo.GetCustomers(customerId);

    //Might argue about which model to accept here, domain's or outer layer's
    public async Task<Customer> AddCustomer(CustomerViewModel customerModel)
    {
        var customer = customerModel.Adapt<Customer>();
        customer.SetId();
        await customerRepo.AddCustomerAsync(customer);
        return customer;
    }

    public async Task UpdateCustomer(Guid customerId, CustomerViewModel updatedPayload)
    {
        var customer = updatedPayload.Adapt<Customer>();
        customer.SetId(customerId);
        await customerRepo.UpdateCustomer(customer);
    }
}
