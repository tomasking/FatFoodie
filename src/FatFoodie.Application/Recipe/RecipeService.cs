using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FatFoodie.Application.Recipe
{
    public class RecipeService : IRecipeService
    {
        public async Task<IEnumerable<Contracts.Recipe>> GetAllRecipes()
        {
            return await Task.Run(
                () =>
                    {
                        if (true) throw new Exception("Oops, you failed again.");
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
