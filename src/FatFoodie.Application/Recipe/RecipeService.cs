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

        public async Task<IEnumerable<Domain.Recipe>> GetAllRecipes()
        {
            var domainRecipes = await recipeRepository.GetAll();

            var recipesDtos = Map(domainRecipes);

            return recipesDtos;
        }

        private IEnumerable<Domain.Recipe> Map(IEnumerable<Domain.Recipe> recipes)
        {
            return recipes.Select(recipe => new Domain.Recipe()
            {
                RecipeId = recipe.RecipeId.Value, Name = recipe.Name
            }).ToList();
        }

        public Domain.Recipe GetRecipesById(int id)
        {
            return new Domain.Recipe() { RecipeId = 1, Name = "Thai Green Curry" };
        }
    }
}
