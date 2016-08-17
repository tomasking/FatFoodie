using System.Collections.Generic;
using System.Linq;

namespace FatFoodie.Application.Recipe
{
    public class RecipeService : IRecipeService
    {
        public IEnumerable<Contracts.Recipe> GetAllRecipes()
        {
            return new[]
            {
                new Contracts.Recipe() {Id = 1, Name = "Thai Green Curry"},
                new Contracts.Recipe() {Id = 2, Name = "Vietnamese Beef and Spinach Soup"}
            };
        }

        public Contracts.Recipe GetRecipesById(int id)
        {
            var matching = GetAllRecipes().SingleOrDefault(r => r.Id == id);
            return matching;
        }
    }
}
