using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FatFoodie.DataAccess;

namespace FatFoodie.Application.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<Contracts.Recipe>> GetAllRecipes()
        {
            var domainRecipes = await recipeRepository.GetAll();

            var recipesDtos = Map(domainRecipes);

            return recipesDtos;
        }

        private IEnumerable<Contracts.Recipe> Map(IEnumerable<Domain.Recipe> recipes)
        {
            return recipes.Select(recipe => new Contracts.Recipe()
            {
                Id = recipe.Id, Name = recipe.Name
            }).ToList();
        }

        public Contracts.Recipe GetRecipesById(int id)
        {
            return new Contracts.Recipe() { Id = 1, Name = "Thai Green Curry" };
        }
    }
}
