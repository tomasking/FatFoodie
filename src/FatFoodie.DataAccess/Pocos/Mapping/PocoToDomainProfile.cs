using AutoMapper;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess.Pocos.Mapping
{
    public class PocoToDomainProfile : Profile
    {
        public PocoToDomainProfile()
        {
            
        }

        public void SomethingPocoToDomainProfile()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RecipePoco, Recipe>());
        }
    }
}
