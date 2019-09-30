using CSharpFunctionalExtensions;
using FluentAssertions;
using ITG.Brix.Mobile.Bff.API.Controllers;
using ITG.Brix.Mobile.Bff.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.UnitTests.API.Controllers
{
    [TestClass]
    public class OperatorControllerTests
    {
        [TestMethod]
        public async Task CreateOperatorActivitiesShouldReturnOKStatusCode()
        {
            //Arrange
            var resultFromService = Result.Ok();
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.CreateOperatorActivities(It.IsAny<JObject>())).Returns(Task.FromResult(resultFromService));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new OperatorController(mobileService);
            var response = await controller.CreateOperatorActivities(new JObject());

            //Assert
            var result = response as JsonResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task CreateOperatorActivitiesShouldReturnBadRequestStatusCode()
        {
            //Arrange
            var resultFromService = Result.Fail("Failure");
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.CreateOperatorActivities(It.IsAny<JObject>())).Returns(Task.FromResult(resultFromService));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new OperatorController(mobileService);
            var response = await controller.CreateOperatorActivities(new JObject());

            //Assert
            var result = response as JsonResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
