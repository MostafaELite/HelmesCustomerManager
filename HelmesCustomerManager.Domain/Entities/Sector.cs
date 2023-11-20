namespace HelmesCustomerManager.Domain.Entities;

public class Sector
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public Guid? ParentSectorId { get; set; }

    public IEnumerable<Sector>? SubSectors { get; set; }
}