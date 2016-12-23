using AutoMapper;

using FatFoodie.Domain;

namespace FatFoodie.Infrastructure.Mapping
{
    public class DomainToContractProfile : Profile
    {
        public DomainToContractProfile()
        {
            CreateMap<Recipe, Contracts.Recipe>();
        }
    }
}
