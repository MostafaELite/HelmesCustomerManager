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
                .NewConfig<CreateCustomerModel, Customer>()
                .Map(dest => dest.Sections, src => src.SelectedSectors);

            config.NewConfig<Guid, Sector>()
                .Map(dest => dest.Id, src => src);

        }
    }
}
