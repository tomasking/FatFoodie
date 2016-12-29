using System.Collections.Generic;
using FatFoodie.Contracts;
using RestSharp;

namespace FatFoodie.EndToEndTests.Http
{
    public class HttpApiWrapper
    {
        public IRestResponse<List<Recipe>> GetAllRecipes()
        {
            var client = new RestClient("http://localhost:9443/");

            var request = new RestRequest("api/recipes", Method.GET);

            // easily add HTTP Headers
            request.AddHeader("header", "value");

            IRestResponse<List<Recipe>> response = client.Execute<List<Recipe>>(request);
            
            return response;
        }
    }
}