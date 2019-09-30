using FluentAssertions;
using ITG.Brix.Mobile.Bff.Application.Models.Api;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services.Builds.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.UnitTests.Application.Services
{
    [TestClass]
    public class FilterBuildServiceTests
    {
        [TestMethod]
        public void BuildFlowFilterShouldSucceed()
        {
            //Arrange
            var service = new FilterBuildService();
            var filterData = new FlowFilterFromBody()
            {
                Source = "source",
                Operation = "operation",
                Site = "site",
                OperationalDepartment = "operational department",
                TypePlanning = "Type planning",
                Customer = "Customer",
                ProductionSite = "Production site",
                TransportType = "Transport type",
                DriverWait = "Yes"
            };
            var expectedFilter = $"source eq '{filterData.Source}' and operation eq '{filterData.Operation}' and site eq '{filterData.Site}' and department eq '{filterData.OperationalDepartment}' and type-planning eq '{filterData.TypePlanning}' and customer eq '{filterData.Customer}' and prodsite eq '{filterData.ProductionSite}' and transport-type eq '{filterData.TransportType}' and driver-wait eq '{filterData.DriverWait}'";

            expectedFilter = Uri.EscapeDataString(expectedFilter);


            //Act
            var filter = service.BuildFlowFilter(filterData);

            //Assert
            filter.Should().Be(expectedFilter);
        }

        [TestMethod]
        public void BuildFlowFilterShouldReturnOnlyEscapedDataUri()
        {
            //Arrange
            var service = new FilterBuildService();
            var filterData = new FlowFilterFromBody()
            {
                Source = "source",
                Operation = "operation",
                Site = "site",
                OperationalDepartment = "operational department",
                TypePlanning = "Type planning",
                Customer = "Customer",
                ProductionSite = "Production site",
                TransportType = "Transport type",
                DriverWait = "Yes"
            };
            var expectedFilter = $"source eq '{filterData.Source}' and operation eq '{filterData.Operation}' and site eq '{filterData.Site}' and department eq '{filterData.OperationalDepartment}' and type-planning eq '{filterData.TypePlanning}' and customer eq '{filterData.Customer}' and prodsite eq '{filterData.ProductionSite}' and transport-type eq '{filterData.TransportType}' and driver-wait eq '{filterData.DriverWait}'";

            //Act
            var filter = service.BuildFlowFilter(filterData);
            filter.Should().NotBe(expectedFilter);
        }

        [TestMethod]
        public void GetMatchLevelShouldReturnRightResult()
        {
            //Arrange
            var service = new FilterBuildService();
            var listSources = new List<FlowSourceModel>()
            {
                new FlowSourceModel{Name = "Source" }
            };
            var sourceToFilter = "Source";

            //Act
            var result = service.GetMatchLevel(listSources, sourceToFilter);

            //Assert
            result.Should().Be(100);
        }

        [TestMethod]
        public void GetMostSpecificFlowShouldReturnTheRightOne()
        {
            //Arrange
            var flows = new List<FlowModel> {
                new FlowModel{
                    Id = new Guid("9db74a82-8d56-4008-bd6e-37c6f39db6df"),
                    Filter = new FlowFilterModel{
                        Sources = new List<FlowSourceModel>(){
                            new FlowSourceModel{ Name = "Source1"},
                            new FlowSourceModel{ Name = "Source2"}
                        },
                        Operations = new List<FlowOperationModel>{
                            new FlowOperationModel{ Name = "Load from warehouse"}
                        },
                        Customers = new List<FlowCustomerModel>{
                            new FlowCustomerModel{ Name = "Exxon"},
                            new FlowCustomerModel{ Name = "Shell"},
                        },
                        Sites = new List<FlowSiteModel>{
                            new FlowSiteModel{ Name = "LB1227"},
                            new FlowSiteModel{ Name = "LB3456"}
                        },
                        OperationalDepartments = new List<FlowOperationalDepartmentModel>{
                            new FlowOperationalDepartmentModel{ Name = "BSG"},
                            new FlowOperationalDepartmentModel{ Name = "ASG"}
                        },
                        ProductionSites = new List<FlowProductionSiteModel>{
                            new FlowProductionSiteModel{ Name = "Site1"},
                            new FlowProductionSiteModel{ Name = "Site2"}
                        },
                        TransportTypes = new List<FlowTransportTypeModel>{
                            new FlowTransportTypeModel{ Name = "Truck"},
                            new FlowTransportTypeModel{ Name = "Train"}
                        },
                        TypePlannings = new List<FlowTypePlanningModel>{
                            new FlowTypePlanningModel{ Name = "Type1"}
                        },
                        DriverWait = "No"
                    }
                },
                new FlowModel{
                    Id = new Guid("6fcd7e30-8dac-4619-8be2-b5a7b15ee12e"),
                    Filter = new FlowFilterModel{
                        Sources = new List<FlowSourceModel>(){
                            new FlowSourceModel{ Name = "Source1"},
                            new FlowSourceModel{ Name = "Source2"},
                            new FlowSourceModel{ Name = "Source3"}
                        },
                        Operations = new List<FlowOperationModel>{
                            new FlowOperationModel{ Name = "Load from warehouse"}
                        },
                        Customers = new List<FlowCustomerModel>{
                            new FlowCustomerModel{ Name = "Exxon"},
                            new FlowCustomerModel{ Name = "Shell"},
                        },
                        Sites = new List<FlowSiteModel>{
                            new FlowSiteModel{ Name = "LB1227"},
                            new FlowSiteModel{ Name = "LB3456"},
                            new FlowSiteModel{ Name = "LB3457"}
                        },
                        OperationalDepartments = new List<FlowOperationalDepartmentModel>{
                            new FlowOperationalDepartmentModel{ Name = "BSG"},
                            new FlowOperationalDepartmentModel{ Name = "ASG"}
                        },
                        ProductionSites = new List<FlowProductionSiteModel>{
                            new FlowProductionSiteModel{ Name = "Site1"},
                            new FlowProductionSiteModel{ Name = "Site2"},
                            new FlowProductionSiteModel{ Name = "Site3"}
                        },
                        TransportTypes = new List<FlowTransportTypeModel>{
                            new FlowTransportTypeModel{ Name = "Truck"},
                            new FlowTransportTypeModel{ Name = "Train"}
                        },
                        TypePlannings = new List<FlowTypePlanningModel>{
                            new FlowTypePlanningModel{ Name = "Type1"}
                        },
                        DriverWait = "Yes"
                    }
                },
                new FlowModel{
                    Id = new Guid("40753e95-9bc3-46a3-860b-6e6c1ebdfdd3"),
                    Filter = new FlowFilterModel{
                        Sources = new List<FlowSourceModel>(){
                            new FlowSourceModel{ Name = "Source1"},
                            new FlowSourceModel{ Name = "Source2"},
                            new FlowSourceModel{ Name = "Source3"}
                        },
                        Operations = new List<FlowOperationModel>{
                            new FlowOperationModel{ Name = "Load from warehouse"}
                        },
                        Customers = new List<FlowCustomerModel>{
                            new FlowCustomerModel{ Name = "x"},
                        },
                        Sites = new List<FlowSiteModel>{
                            new FlowSiteModel{ Name = "LB1227"},
                            new FlowSiteModel{ Name = "LB3456"},
                            new FlowSiteModel{ Name = "LB3457"}
                        },
                        OperationalDepartments = new List<FlowOperationalDepartmentModel>{
                            new FlowOperationalDepartmentModel{ Name = "BSG"},
                            new FlowOperationalDepartmentModel{ Name = "ASG"}
                        },
                        ProductionSites = new List<FlowProductionSiteModel>{
                            new FlowProductionSiteModel{ Name = "x"}
                        },
                        TransportTypes = new List<FlowTransportTypeModel>{
                            new FlowTransportTypeModel{ Name = "Truck"},
                            new FlowTransportTypeModel{ Name = "Train"}
                        },
                        TypePlannings = new List<FlowTypePlanningModel>{
                            new FlowTypePlanningModel{ Name = "Type1"}
                        },
                        DriverWait = "Yes"
                    }
                }
            };
            var filter = new FlowFilterFromBody
            {
                Source = "Source1",
                Operation = "Load from warehouse",
                Customer = "Exxon",
                Site = "LB1227",
                OperationalDepartment = "BSG",
                ProductionSite = "Site1",
                TransportType = "Truck",
                TypePlanning = "Type1",
                DriverWait = "No"
            };
            var service = new FilterBuildService();

            //Act
            var result = service.GetMostSpecificFlow(flows, filter);

            //Assert
            result.Id.Should().Be(new Guid("9db74a82-8d56-4008-bd6e-37c6f39db6df"));
        }
    }
}
