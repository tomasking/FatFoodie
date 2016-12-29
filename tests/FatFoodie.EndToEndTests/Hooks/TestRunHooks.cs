using System;
using FatFoodie.Api;
using FatFoodie.EndToEndTests.LocalDb;
using Microsoft.Owin.Hosting;
using TechTalk.SpecFlow;

namespace FatFoodie.EndToEndTests.Hooks
{
    [Binding]
    public class TestRunHooks
    {
        private static IDisposable inMemoryApi;
        
        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            DatabaseExtensions.DeployLocalDb();
            inMemoryApi = WebApp.Start<Startup>("http://*:9443/");
        }

        [AfterTestRun]
        public static void RunAfterAllTests()
        {
            inMemoryApi.Dispose();
        }

        [BeforeScenario]
        public static void RunBeforeEachTest()
        {
            DatabaseExtensions.ClearAllTables();
        }
    }
}
