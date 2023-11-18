namespace HelmesCustomerManager.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<Sector> Sections { get; set; }

    internal void GenerateId() => Id = Guid.NewGuid();
}