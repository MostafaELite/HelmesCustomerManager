using HelmesCustomerManager.Domain.RepositoryInterfaces;
using HelmesCustomerManager.Domain.Services;
using HelmesCustomerManager.Persistence;
using HelmesCustomerManager.Persistence.Repos;

namespace HelmesCustomerManager.Api
{
    internal class ApiConfig
    {
        internal static async Task ConfigreDBAsync(IServiceCollection services)
        {
            services.AddDbContext<HelmesContext>();
            await using var context = new HelmesContext();
            context.Database.EnsureCreated();
        }

        internal static void RegisterRepos(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ISectorRepository, SectorRepository>();            
        }    

        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
