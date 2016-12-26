using System.Net.Http;
using System.Threading.Tasks;
using FatFoodie.EndToEndTests.LocalDb;
using FatFoodie.WebApi;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.TestHost;
using NUnit.Framework;

namespace FatFoodie.EndToEndTests
{
    [TestFixture]
    public class EndToEndTest
    {
        private TestServer _server;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            DatabaseExtensions.DeployLocalDb();
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [SetUp]
        public void SetUp()
        {
            DatabaseExtensions.ClearAllTables();
        }

        [Test]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
