using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;

using FatFoodie.Configuration;
using FatFoodie.DataAccess.Pocos;
using FatFoodie.Domain;

namespace FatFoodie.DataAccess
{
    public class SqlRecipeRepository : IRecipeRepository
    {
        private readonly IMapper mapper;

        public readonly string ConnectionString;

        public SqlRecipeRepository(IConfigurationSettings configurationSettings, IMapper mapper)
        {
            this.mapper = mapper;
            ConnectionString = configurationSettings.RecipeConnectionString;
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var resultList = await conn.QueryAsync<RecipePocoWithId>(@"SELECT * FROM Recipe");

                var recipes = mapper.Map<IEnumerable<Recipe>>(resultList);
                return recipes;
            }
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var recipePoco = await conn.QueryAsync<RecipePocoWithId>("spRecipeGet", new { RecipeId = recipeId }, commandType: CommandType.StoredProcedure);
                return mapper.Map<Recipe>(recipePoco.Single());
            }
        }

        public async Task Add(Recipe recipe)
        {
            using (var conn = new SqlConnection(ConnectionString))
            { 
                var recipePoco = mapper.Map<RecipePoco>(recipe);
                var returnValues = await conn.QueryAsync<int>("spRecipeInsert", recipePoco, commandType: CommandType.StoredProcedure);
                recipe.RecipeId = returnValues.Single();
            }
        }

        public async Task Delete(int recipeId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                await conn.ExecuteAsync("spRecipeDelete", new { RecipeId = recipeId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
