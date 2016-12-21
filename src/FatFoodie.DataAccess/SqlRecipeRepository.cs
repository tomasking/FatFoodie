using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using FatFoodie.DataAccess.Pocos;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public class SqlRecipeRepository : IRecipeRepository
    {
        private readonly string connectionString;

        public SqlRecipeRepository()
        {
        }

        public Task<IEnumerable<Recipe>> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var resultList = conn.Query<RecipePoco>(@"SELECT * FROM Recipe");
                var recipes = Mapper.Map<IEnumerable<Recipe>>(resultList);
                return Task.FromResult(recipes);
            }
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
