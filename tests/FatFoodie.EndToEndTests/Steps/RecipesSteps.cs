using System.Collections.Generic;
using System.Net;
using FatFoodie.Contracts;
using FatFoodie.EndToEndTests.Http;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;

namespace FatFoodie.EndToEndTests.Steps
{
    [Binding]
    public class RecipesSteps
    {
        private readonly HttpApiWrapper httpApiWrapper;

        public RecipesSteps()
        {
            httpApiWrapper = new HttpApiWrapper();
        }

        [When(@"I get all recipes")]
        public void WhenIGetAllRecipes()
        {
            var response = httpApiWrapper.GetAllRecipes();
            ScenarioContext.Current["Response"] = response;
        }

        [Then(@"I should get an empty list of recipes")]
        public void ThenIShouldGetAnEmptyListOfRecipes()
        {
            var response =(IRestResponse<List<Recipe>>) ScenarioContext.Current["Response"];

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().BeEmpty();
        }
    }
}
