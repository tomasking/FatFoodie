using AutoMapper;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess.Pocos.Mapping
{
    public class PocoToDomainProfile : Profile
    {
        public PocoToDomainProfile()
        {
            CreateMap<RecipePoco, Recipe>();
        }
    }
}
