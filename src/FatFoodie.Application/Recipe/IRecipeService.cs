using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatFoodie.Application.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<Domain.Recipe>> GetAllRecipes();

        Task<Domain.Recipe> GetRecipesById(int id);

        Task<Domain.Recipe> AddOrUpdateRecipe(Domain.Recipe recipe);
    }
}