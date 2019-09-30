using CSharpFunctionalExtensions;
using FluentAssertions;
using ITG.Brix.Mobile.Bff.API.Controllers;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.UnitTests.API.Controllers
{
    [TestClass]
    public class OrdersControllerTests
    {
        [TestMethod]
        public void ConstructorShouldSucceed()
        {
            //Arrange
            var mobileService = new Mock<IMobileService>().Object;

            //Act
            var controller = new OrdersController(mobileService);

            //Assert
            controller.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldFailWhenMobileServiceIsNull()
        {
            //Arrange
            IMobileService mobileService = null;

            //Act
            var controller = new OrdersController(mobileService);
        }

        [TestMethod]
        public async Task UpdateStatusShouldReturnNoContentStatus()
        {
            //Arrange
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.UpdateWorkOrderStatus(It.IsAny<UpdateOrderStatusFromBody>())).Returns(Task.FromResult(Result.Ok("123456")));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new OrdersController(mobileService);
            var response = await controller.UpdateOrderStatus(new UpdateOrderStatusFromBody());

            //Assert
            var result = response as JsonResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task UpdateStatusShouldReturnBadRequestWhenResultIsFailure()
        {
            //Arrange
            var mobileServiceMock = new Mock<IMobileService>();
            mobileServiceMock.Setup(x => x.UpdateWorkOrderStatus(It.IsAny<UpdateOrderStatusFromBody>())).Returns(Task.FromResult(Result.Fail<string>("Test")));
            var mobileService = mobileServiceMock.Object;

            //Act
            var controller = new OrdersController(mobileService);
            var response = await controller.UpdateOrderStatus(new UpdateOrderStatusFromBody());

            //Assert
            var result = response as JsonResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
