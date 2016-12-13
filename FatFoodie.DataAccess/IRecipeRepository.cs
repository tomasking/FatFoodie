using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAll();

        Recipe GetById(int recipeId);

        void Add(Recipe recipe);

        void Delete(int recipeId);
    }
}
