using FluentAssertions;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Location;
using ITG.Brix.Mobile.Bff.Application.Models.Local;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location;
using ITG.Brix.Mobile.Bff.Application.Services.Builds.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.UnitTests.Application.Services
{
    [TestClass]
    public class LocationBuildServiceTests
    {
        [TestMethod]
        public void BuildLocationShouldSucceed()
        {
            //Arrange
            var locationsModel = new LocationsModel
            {
                Value = new List<LocationLocalModel>
                {
                    new LocationLocalModel{
                        Warehouse = "Warehouse B",
                        Gate = "DB",
                        Row = "3",
                        Position = "001",
                        Site = "LB1227"
                    }
                }
            };

            //Act
            var service = new LocationBuildService();
            var result = service.BuildLocation(locationsModel);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<LocationSiteModel>();
        }
    }
}
