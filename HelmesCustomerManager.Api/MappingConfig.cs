using HelmesCustomerManager.Domain.Dtos;
using HelmesCustomerManager.Domain.Entities;
using Mapster;

namespace HelmesCustomerManager.Api
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.RequireExplicitMapping = false;
            config.RequireDestinationMemberSource = false;
            config
                .ForType<Customer, CustomerViewModel>()
                .TwoWays()
                .Map(dest => dest.SelectedSectors, src => src.Sectors);

            config.NewConfig<Guid, Sector>()
                .Map(dest => dest.Id, src => src);


            config.NewConfig<Sector, Guid>()
                .MapWith(sector => sector.Id);

        }
    }
}
