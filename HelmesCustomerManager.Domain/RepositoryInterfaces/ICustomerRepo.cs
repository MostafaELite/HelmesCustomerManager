using HelmesCustomerManager.Domain.Entities;

namespace HelmesCustomerManager.Domain.RepositoryInterfaces
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customerModel);

        IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds);
    }
}