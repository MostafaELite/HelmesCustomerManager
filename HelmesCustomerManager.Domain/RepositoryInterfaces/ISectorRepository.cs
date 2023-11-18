using HelmesCustomerManager.Domain.Entities;

namespace HelmesCustomerManager.Persistence.Repos
{
    public interface ISectorRepository
    {
        IEnumerable<Sector> GetSectors();
    }
}