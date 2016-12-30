using System.Collections.Generic;
using System.Net;
using FatFoodie.Contracts;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;

namespace FatFoodie.EndToEndTests.Steps
{
    [Binding]
    public class RecipesResponseSteps
    {
        [Then(@"I should get an empty list of recipes")]
        public void ThenIShouldGetAnEmptyListOfRecipes()
        {
            var response =(IRestResponse<List<Recipe>>) ScenarioContext.Current[ScenarioContextConstants.AllRecipesResponse];

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().BeEmpty();
        }
        
        [Then(@"I should get the recipe returned")]
        public void ThenIShouldGetTheRecipeReturned()
        {
            var response = (IRestResponse<Recipe>)ScenarioContext.Current[ScenarioContextConstants.RecipeResponse];

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var addedRecipe = (Recipe)ScenarioContext.Current[ScenarioContextConstants.AddRecipeRequest];
            response.Data.Should().Be(addedRecipe);
        }
    }
}
