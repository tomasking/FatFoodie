using System;
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
                    new Recipe() { RecipeId = 1, Name = "Thai Green Curry" },
                    new Recipe() { RecipeId = 2, Name = "Vietnamese Beef and Spinach Soup" }
                });
        }
        
        public Task<Recipe> GetById(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> Add(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}