using CSharpFunctionalExtensions;
using FluentAssertions;
using ITG.Brix.Mobile.Bff.API.Controllers;
using ITG.Brix.Mobile.Bff.Application.Models;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services;
using ITG.Brix.Mobile.Bff.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.UnitTests.API.Controllers
{
    [TestClass]
    public class SetupControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldFailWhenMobileServiceIsNull()
        {
            //Act
            MobileService service = null;
            new SetupController(service);
        }

        [TestMethod]
        public async Task GetFlowShouldReturnOKStatusCode()
        {
            var flowLocal = Result.Ok(new FlowDataModel() { Name = "Test" });
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.GetFlow(It.IsAny<FlowFilterFromBody>())).Returns(Task.FromResult(flowLocal));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new SetupController(mobileService);
            var response = await controller.GetFlow(new FlowFilterFromBody());

            //Assert
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetFlowShouldReturnNoContentResultWhenNoFlowFound()
        {
            //Arrange
            FlowDataModel model = null;
            var flowLocal = Result.Ok(model);
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.GetFlow(It.IsAny<FlowFilterFromBody>())).Returns(Task.FromResult(flowLocal));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new SetupController(mobileService);
            var response = await controller.GetFlow(new FlowFilterFromBody());

            //Assert
            var result = response as NoContentResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task GetFlowShouldReturnBadRequestWhenResultIsFailure()
        {
            //Arrange
            var flowLocal = Result.Fail<FlowDataModel>("Bad request to EccSetup.API");
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.GetFlow(It.IsAny<FlowFilterFromBody>())).Returns(Task.FromResult(flowLocal));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new SetupController(mobileService);
            var response = await controller.GetFlow(new FlowFilterFromBody());

            //Asert
            var result = response as BadRequestResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }       
    }
}
