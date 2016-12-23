using AutoMapper;

using FatFoodie.DataAccess.Pocos;
using FatFoodie.Domain;

namespace FatFoodie.Infrastructure.Mapping
{
    public class PocoToDomainProfile : Profile
    {
        public PocoToDomainProfile()
        {
            CreateMap<RecipePocoWithId, Recipe>();
            CreateMap<Recipe, RecipePoco>().ForSourceMember(dest => dest.RecipeId, options => options.Ignore());
        }
    }
}
