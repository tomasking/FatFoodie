using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public class SqlRecipeRepository : IRecipeRepository
    {
        private readonly string connectionString;

        public SqlRecipeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Task<IEnumerable<Recipe>> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                IEnumerable<Recipe> resultList = conn.Query<Recipe>(@"SELECT * FROM Recipe");
                return Task.FromResult(resultList);
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
