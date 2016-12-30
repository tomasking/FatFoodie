using System.Collections.Generic;
using FatFoodie.Contracts;
using RestSharp;

namespace FatFoodie.EndToEndTests.Http
{
    public class HttpApiWrapper
    {
        private static string baseUrl = "http://localhost:9443/";
        private string recipesUrl = "api/recipes";

        public IRestResponse<List<Recipe>> GetAllRecipes()
        {
            var request = new RestRequest(recipesUrl, Method.GET);
            return ExecuteRequest<List<Recipe>>(request);
        }

        public IRestResponse<Recipe> AddRecipe(Recipe recipeToAdd)
        {
            var request = new RestRequest(recipesUrl, Method.POST);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddJsonBody(recipeToAdd);
            return ExecuteRequest<Recipe>(request);
        }

        public IRestResponse<Recipe> GetRecipeById(int recipeId)
        {
            var request = new RestRequest($"{recipesUrl}/{recipeId}", Method.GET);
            return ExecuteRequest<Recipe>(request);
        }

        private static IRestResponse<T> ExecuteRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(baseUrl);
            IRestResponse<T> response = client.Execute<T>(request);
            return response;
        }
    }
}