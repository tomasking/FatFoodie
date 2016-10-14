using System.Collections.Generic;
using System.Threading.Tasks;
using FatFoodie.Contracts.Exceptions;

namespace FatFoodie.Application.Recipe
{
    public class RecipeService : IRecipeService
    {
        public async Task<IEnumerable<Contracts.Recipe>> GetAllRecipes()
        {
            return await Task.Run(
                () =>
                {
                    throw new DatabaseUnavailableException("db exception");
                        return new[]
                               {
                                   new Contracts.Recipe() { Id = 1, Name = "Thai Green Curry" },
                                   new Contracts.Recipe() { Id = 2, Name = "Vietnamese Beef and Spinach Soup" }
                               };
                    });
        }

        public Contracts.Recipe GetRecipesById(int id)
        {
            return new Contracts.Recipe() { Id = 1, Name = "Thai Green Curry" };
        }
    }
}
