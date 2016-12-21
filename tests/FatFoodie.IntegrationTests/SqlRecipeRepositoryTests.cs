using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatFoodie.DataAccess;
using FatFoodie.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace FatFoodie.IntegrationTests
{
    [TestFixture]
    public class SqlRecipeRepositoryTests
    {
        private SqlRecipeRepository sqlRecipeRepository;

        [SetUp]
        public void Setup()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Recipe"];
            sqlRecipeRepository = new SqlRecipeRepository();
        }

        [Test]
        public async Task ShouldReturnNoRecipes_WhenGetAllCalled()
        {
            var recipes = await sqlRecipeRepository.GetAll();

            recipes.Should().NotBeNull();
        }

        [Test]
        public async void ShouldReturnARecipe_GivenWeHaveAddedOne()
        {
            var recipe = new Recipe()
            {
                Name = "New One"
            };

            sqlRecipeRepository.Add(recipe);

            var recipes = await sqlRecipeRepository.GetAll();

            recipes.Should().NotBeNull();
            recipes.Should().Contain(r => r == recipe);
        }
    }
}
