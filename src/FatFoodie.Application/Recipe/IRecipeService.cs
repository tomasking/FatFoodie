using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatFoodie.Application.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<Domain.Recipe>> GetAllRecipes();

        Domain.Recipe GetRecipesById(int id);
    }
}