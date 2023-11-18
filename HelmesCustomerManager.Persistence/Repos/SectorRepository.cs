using HelmesCustomerManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelmesCustomerManager.Persistence.Repos
{
    public class SectorRepository(HelmesContext db) : ISectorRepository
    {
        private readonly HelmesContext _db = db;

        public IEnumerable<Sector> GetSectors()
        {
            var sectors = _db.Sectors
                .Include(q => q.SubSectors)
                .ThenInclude(s => s.SubSectors)
                .Where(qw => qw.ParentSectorId == null)
                .AsNoTracking()
                .ToArray();

            return sectors;
        }
    }
}
