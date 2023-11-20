namespace HelmesCustomerManager.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public  required ICollection<Sector> Sectors { get; set; }

    internal void SetId(Guid? customerId = null) => Id = customerId ?? Guid.NewGuid();
}