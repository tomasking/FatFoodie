using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FatFoodie.Contracts;
using RestSharp;
using Should;
using TechTalk.SpecFlow;

namespace FatFoodie.AcceptanceTests.Steps
{
    [Binding]
    public sealed class GetRecipeSteps
    {
        [Given(@"I have recipes previously saved")]
        public void GivenIHaveRecipesPreviouslySaved()
        {
            
        }

        [When(@"I get a list of all recipes")]
        public void WhenIGetAListOfAllRecipes()
        {
            var client = new RestClient("http://localhost:5000/");
            var request = new RestRequest("api/recipe", Method.GET);

            ScenarioContext.Current.Set(client.Execute<List<Recipe>>(request));
        }

        [Then(@"all the recipes are returned")]
        public void ThenAllTheRecipesAreReturned()
        {
            var restResponse = ScenarioContext.Current.Get<IRestResponse<List<Recipe>>>();

            restResponse.StatusCode.ShouldEqual(HttpStatusCode.OK);
            var recipes = restResponse.Data;
            recipes.ShouldNotBeNull();
            recipes.ShouldNotBeEmpty();
        }
    }
}
