using ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net.Http;

namespace ITG.Brix.Mobile.Bff.UnitTests.Infrastructure.RestApis
{
    [TestClass]
    public class EccSetupRestApiTests
    {
        [TestMethod]
        public void ConstructorShouldSucceed()
        {
            //Arrange
            var httpClient = new Mock<HttpClient>().Object;

            //Act
            new EccSetupRestApi(httpClient);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldFailWhenHttpClientIsNull()
        {
            //Arrange
            HttpClient client = null;

            //Act
            new EccSetupRestApi(client);
        }
    }
}
