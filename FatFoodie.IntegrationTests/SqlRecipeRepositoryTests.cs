using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatFoodie.DataAccess;
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
            sqlRecipeRepository = new SqlRecipeRepository(connectionString.ConnectionString);
        }

        [Test]
        public async Task ShouldReturnRecipes_WhenGetAllCalled()
        {
            var recipes = await sqlRecipeRepository.GetAll();

            recipes.Should().NotBeNull();
        }
    }
}
