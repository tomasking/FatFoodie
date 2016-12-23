

using FatFoodie.Application.Recipe;
using FatFoodie.DataAccess;

using FluentAssertions;

using NUnit.Framework;

namespace FatFoodie.UnitTests.Application.Recipe
{
    public class RecipeServiceTests
    {
        private IRecipeService recipeService;

        [SetUp]
        public void Setup()
        {
            recipeService = new RecipeService(new InMemoryRecipeRepository());
        }

        [Test]
        public void TestSomething()
        {
            var recipes = recipeService.GetAllRecipes();

            recipes.Should().NotBeNull();
        }
    }
}
