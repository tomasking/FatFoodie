using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatFoodie.Application.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<Contracts.Recipe>> GetAllRecipes();

        Contracts.Recipe GetRecipesById(int id);
    }
}