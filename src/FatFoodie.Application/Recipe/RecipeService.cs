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
            return domainRecipes;
        }
        
        public async Task<Domain.Recipe> GetRecipesById(int id)
        {
            var recipeResponse = await recipeRepository.GetById(id);
            return recipeResponse;
        }

        public async Task<Domain.Recipe> AddOrUpdateRecipe(Domain.Recipe recipe)
        {
            var recipeResponse = await recipeRepository.Add(recipe);
            return recipeResponse;
        }
    }
}
