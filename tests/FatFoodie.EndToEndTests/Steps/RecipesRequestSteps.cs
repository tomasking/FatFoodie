using FatFoodie.Contracts;
using FatFoodie.EndToEndTests.Http;
using RestSharp;
using TechTalk.SpecFlow;

namespace FatFoodie.EndToEndTests.Steps
{
    [Binding]
    public class RecipesRequestSteps
    {
        private readonly HttpApiWrapper httpApiWrapper;

        public RecipesRequestSteps()
        {
            httpApiWrapper = new HttpApiWrapper();
        }

        [When(@"I get all recipes")]
        public void WhenIGetAllRecipes()
        {
            var response = httpApiWrapper.GetAllRecipes();
            ScenarioContext.Current[ScenarioContextConstants.AllRecipesResponse] = response;
        }
        
        [Given(@"I have added a recipe")]
        [When(@"I add a new recipe")]
        public void WhenIAddANewRecipe()
        {
            var recipeToAdd = new Recipe()
            {
                Name = "Pumpking Pie"
            };
            ScenarioContext.Current[ScenarioContextConstants.AddRecipeRequest] = recipeToAdd;

            var response = httpApiWrapper.AddRecipe(recipeToAdd);
            ScenarioContext.Current[ScenarioContextConstants.RecipeResponse] = response;
        }
        
        [When(@"I get the recipe by Id")]
        public void WhenIAddGetTheRecipeById()
        {
            var addRecipeResponse = (IRestResponse<Recipe>)ScenarioContext.Current[ScenarioContextConstants.RecipeResponse];
            var response = httpApiWrapper.GetRecipeById(addRecipeResponse.Data.RecipeId.Value);
            ScenarioContext.Current[ScenarioContextConstants.RecipeResponse] = response;
        }
    }
}
