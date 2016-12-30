using AutoMapper;
using FatFoodie.Domain;

namespace FatFoodie.Infrastructure.Mapping
{
    public class ContractToDomainProfile : Profile
    {
        public ContractToDomainProfile()
        {
            CreateMap<Contracts.Recipe, Recipe>();
        }
    }
}