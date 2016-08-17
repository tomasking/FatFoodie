using System.Collections.Generic;

namespace FatFoodie.Application.Recipe
{
    public interface IRecipeService
    {
        IEnumerable<Contracts.Recipe> GetAllRecipes();

        Contracts.Recipe GetRecipesById(int id);
    }
}