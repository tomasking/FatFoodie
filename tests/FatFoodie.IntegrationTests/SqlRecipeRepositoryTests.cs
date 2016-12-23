using System;
using System.Configuration;
using System.Threading.Tasks;

using AutoMapper;

using FatFoodie.Configuration;
using FatFoodie.DataAccess;
using FatFoodie.Domain;
using FluentAssertions;

using NSubstitute;

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
            IConfigurationSettings configurationSettings = Substitute.For<IConfigurationSettings>();
            configurationSettings.RecipeConnectionString.Returns(connectionString.ConnectionString);
            var mapper = new MapperConfiguration(cfg => { cfg.AddProfiles(typeof(IDataAccessRegistrationMarker)); }).CreateMapper();

            sqlRecipeRepository = new SqlRecipeRepository(configurationSettings, mapper);
        }

        [Test]
        public async Task ShouldNotBeNull_WhenGetAllCalled()
        {
            var recipes = await sqlRecipeRepository.GetAll();

            recipes.Should().NotBeNull();
        }

        [Test]
        public void ShouldBeAbleToRetrieveRecipe_GivenWeHaveAddedOne()
        {
            var recipe = new Recipe { Name = "New One" };

            sqlRecipeRepository.Add(recipe);
            recipe.RecipeId.Should().NotBeNull();

            var retrievedRecipe = sqlRecipeRepository.GetById(recipe.RecipeId.Value);
            retrievedRecipe.Should().NotBeNull();
            retrievedRecipe.Should().Be(recipe);
        }

        [Test]
        public void ShouldDeleteItem_GivenWeHaveAddedOne()
        {
            var recipe = new Recipe { Name = Guid.NewGuid().ToString() };
            sqlRecipeRepository.Add(recipe);
            
            sqlRecipeRepository.Delete(recipe.RecipeId.Value);

            var deletedRecipe = sqlRecipeRepository.GetById(recipe.RecipeId.Value);
            deletedRecipe.Should().BeNull();
        }
    }
}
