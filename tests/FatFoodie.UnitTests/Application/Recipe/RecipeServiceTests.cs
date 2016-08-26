using FatFoodie.Application.Recipe;

using NUnit.Framework;

namespace FatFoodie.UnitTests.Application.Recipe
{
    public class RecipeServiceTests
    {
        private IRecipeService recipeService;

        [SetUp]
        public void Setup()
        {
            recipeService = new RecipeService();
        }

        [Test]
        public void TestSomething()
        {
            var recipes = recipeService.GetAllRecipes();

            Assert.That(recipes, Is.Not.Null);
        }
    }
}
