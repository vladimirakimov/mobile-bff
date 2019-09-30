using FluentAssertions;
using ITG.Brix.Mobile.Bff.IntegrationTests.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.IntegrationTests.Controllers
{
    [TestClass]
    [TestCategory("Integration")]
    public class OrderControllerTests
    {
        private HttpClient _client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ControllerTestHelper.InitServer();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _client = ControllerTestHelper.GetClient();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task GetShouldSucceed()
        {
            // Arrange
            var request = new List<string>() { "source", "customer-name" };

            var jsonBody = JsonConvert.SerializeObject(request);

            // Act
            var response = await _client.PostAsync("api/orders/overview", new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
    }
}
