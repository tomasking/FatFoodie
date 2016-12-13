using System.Collections.Generic;
using System.Threading.Tasks;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await Task.Run(
                () => new[]
                {
                    new Recipe() { Id = 1, Name = "Thai Green Curry" },
                    new Recipe() { Id = 2, Name = "Vietnamese Beef and Spinach Soup" }
                });
        }

        public Recipe GetById(int recipeId)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int recipeId)
        {
            throw new System.NotImplementedException();
        }
    }
}