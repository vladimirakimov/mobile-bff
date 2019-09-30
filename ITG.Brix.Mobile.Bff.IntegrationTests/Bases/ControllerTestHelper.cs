using ITG.Brix.Mobile.Bff.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;


namespace ITG.Brix.Mobile.Bff.IntegrationTests.Bases
{
    public static class ControllerTestHelper
    {
        private static TestServer _server;
        public static void InitServer()
        {
            var config = new ConfigurationBuilder().AddJsonFile("settings.json", optional: true).Build();
            _server = new TestServer(new WebHostBuilder().UseConfiguration(config).UseStartup<Startup>());
        }

        public static HttpClient GetClient()
        {
            var client = _server.CreateClient();
            return client;
        }
    }
}
