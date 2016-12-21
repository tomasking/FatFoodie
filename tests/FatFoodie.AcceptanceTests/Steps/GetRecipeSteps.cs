using System.Collections.Generic;
using System.Net;

using FatFoodie.Contracts;

using FluentAssertions;

using RestSharp;

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

            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var recipes = restResponse.Data;
            recipes.Should().NotBeNull();
            recipes.Should().NotBeEmpty();
        }
    }
}
