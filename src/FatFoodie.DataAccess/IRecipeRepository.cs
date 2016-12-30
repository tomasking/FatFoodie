using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAll();

        Task<Recipe> GetById(int recipeId);

        Task<Recipe> Add(Recipe recipe);

        Task Delete(int recipeId);
    }
}
