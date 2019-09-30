using AutoMapper;
using FluentAssertions;
using ITG.Brix.Mobile.Bff.Application.Mappers;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Damage;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Location;
using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services.Builds;
using ITG.Brix.Mobile.Bff.Application.Services.Converters;
using ITG.Brix.Mobile.Bff.Application.Services.Impl;
using ITG.Brix.Mobile.Bff.Application.Services.Jsons;
using ITG.Brix.Mobile.Bff.Infrastructure.RestApis;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.UnitTests.Application
{
    [TestClass]
    public class MobileServiceTests
    {
        [TestMethod]
        public async Task GetFlowsShouldSucceed()
        {
            //Arrange    
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var workOrdersRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var filterString = "source%20eq%20%27source%27%20and%20operation%20eq%20%27operation%27%20and%20site%20eq%20%27site%27%20and%20department%20eq%20%27operational%20department%27%20and%20type-planning%20eq%20%27Type%20planning%27%20and%20customer%20eq%20%27Customer%27%20and%20prodsite%20eq%20%27Production%20site%27%20and%20transport-type%20eq%20%27Transport%20type%27%20and%20driver-wait%20eq%20%27Yes%27";
            var filterBuildServiceMock = new Mock<IFilterBuildService>();
            filterBuildServiceMock.Setup(x => x.BuildFlowFilter(It.IsAny<FlowFilterFromBody>())).Returns(filterString);

            var filterBuildService = filterBuildServiceMock.Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.OK;
            responseMessage.Content = new StringContent("{\"count\":1,\"nextLink\":null,\"value\":[{\"id\":\"5fb3e62e-120d-49c7-8939-c0d7f93ee5ae\",\"name\":\"UpdatedName\",\"description\":\"Description\",\"image\":\"Image\",\"diagram\":\"diagram\",\"filterContent\":\"{}\",\"filter\":{\"sources\":[{\"name\":\"x\"}],\"operations\":[{\"name\":\"x\"}],\"sites\":[{\"name\":\"x\"}],\"operationalDepartments\":[{\"name\":\"x\"}],\"typePlannings\":[{\"name\":\"x\"}],\"customers\":[{\"name\":\"x\"}],\"productionSites\":[{\"name\":\"x\"}],\"transportTypes\":[{\"name\":\"x\"}],\"driverWait\":\"x\"}}]}");

            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.GetFlow(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;

            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrdersRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.GetFlow(new FlowFilterFromBody());

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetFlowsShouldReturnFailureWhenBadRequestReceivedFromApi()
        {
            //Arrange   
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var workOrdersRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var filterString = "source%20eq%20%27source%27%20and%20operation%20eq%20%27operation%27%20and%20site%20eq%20%27site%27%20and%20department%20eq%20%27operational%20department%27%20and%20type-planning%20eq%20%27Type%20planning%27%20and%20customer%20eq%20%27Customer%27%20and%20prodsite%20eq%20%27Production%20site%27%20and%20transport-type%20eq%20%27Transport%20type%27%20and%20driver-wait%20eq%20%27Yes%27";
            var filterBuildServiceMock = new Mock<IFilterBuildService>();
            filterBuildServiceMock.Setup(x => x.BuildFlowFilter(It.IsAny<FlowFilterFromBody>())).Returns(filterString);

            var filterBuildService = filterBuildServiceMock.Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            responseMessage.Content = new StringContent("{\"count\":1,\"nextLink\":null,\"value\":[{\"id\":\"5fb3e62e-120d-49c7-8939-c0d7f93ee5ae\",\"name\":\"UpdatedName\",\"description\":\"Description\",\"image\":\"Image\",\"diagram\":\"diagram\",\"filterContent\":\"{}\",\"filter\":{\"sources\":[{\"name\":\"x\"}],\"operations\":[{\"name\":\"x\"}],\"sites\":[{\"name\":\"x\"}],\"operationalDepartments\":[{\"name\":\"x\"}],\"typePlannings\":[{\"name\":\"x\"}],\"customers\":[{\"name\":\"x\"}],\"productionSites\":[{\"name\":\"x\"}],\"transportTypes\":[{\"name\":\"x\"}],\"driverWait\":\"x\"}}]}");

            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.GetFlow(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;

            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrdersRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.GetFlow(new FlowFilterFromBody());

            //Assert
            response.IsFailure.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetWorkOrderByIdShouldFailWhenRequestToServiceFails()
        {
            //Arrange     
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            responseMessage.Content = new StringContent("{bad}");
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var workOrdersRestApiMock = new Mock<IWorkOrdersRestApi>();
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            workOrdersRestApiMock.Setup(x => x.GetOrder(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrdersRestApi = workOrdersRestApiMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;
            var mapper = new Mock<IMapper>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                 teamsRestApi,
                                                 eccSetupRestApi,
                                                 workOrdersRestApi,
                                                 filterMapper,
                                                 filterBuildService,
                                                 jsonService,
                                                 locationBuildService,
                                                 modelDtoConverter,
                                                 mapper);

            //Act
            var response = await mobileService.GetWorkOrderById(Guid.NewGuid());

            //Assert
            response.IsFailure.Should().Be(true);
        }

        [TestMethod]
        public async Task GetWorkOrderByIdShouldSucceed()
        {
            //Arrange 
            var id = new Guid("76122118-5f89-4715-8360-c78d1fa95c1a");
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.Headers.Add("ETag", "\"12340000\"");
            responseMessage.StatusCode = HttpStatusCode.OK;
            responseMessage.Content = new StringContent("{\r\n    \"id\" : \"76122118-5f89-4715-8360-c78d1fa95c1a\"\r\n}");
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var workOrdersRestApiMock = new Mock<IWorkOrdersRestApi>();
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            workOrdersRestApiMock.Setup(x => x.GetOrder(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrdersRestApi = workOrdersRestApiMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                 teamsRestApi,
                                                 eccSetupRestApi,
                                                 workOrdersRestApi,
                                                 filterMapper,
                                                 filterBuildService,
                                                 jsonService,
                                                 locationBuildService,
                                                 modelDtoConverter,
                                                 mapper);

            //Act
            var response = await mobileService.GetWorkOrderById(id);

            //Assert
            response.IsSuccess.Should().Be(true);
            response.Value.Id.Should().Be(id);
        }

        [TestMethod]
        public async Task GetWorkOrderWithFlowShouldFailIfGetOrderByIdFails()
        {
            //Arrange 
            var id = new Guid("76122118-5f89-4715-8360-c78d1fa95c1a");
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            responseMessage.Content = new StringContent("{bad}");
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var workOrdersRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrdersRestApiMock.Setup(x => x.GetOrder(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrdersRestApi = workOrdersRestApiMock.Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                 teamsRestApi,
                                                 eccSetupRestApi,
                                                 workOrdersRestApi,
                                                 filterMapper,
                                                 filterBuildService,
                                                 jsonService,
                                                 locationBuildService,
                                                 modelDtoConverter,
                                                 mapper);


            var response = await mobileService.GetWorkOrderWithFlow(new StartOrderFromBody() { Id = id, Login = "Karl" });

            //Assert
            response.IsFailure.Should().Be(true);
        }

        [TestMethod]
        public async Task GetWorkOrderWithFlowShouldSucceed()
        {
            // Arrange 
            var id = new Guid("76122118-5f89-4715-8360-c78d1fa95c1a");
            var jsonService = new Mock<IJsonService<object>>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;

            var responseMessageGetFlow = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"count\":1,\"nextLink\":null,\"value\":[{\"id\":\"5fb3e62e-120d-49c7-8939-c0d7f93ee5ae\",\"name\":\"UpdatedName\",\"description\":\"Description\",\"image\":\"Image\",\"diagram\":\"diagram\",\"filterContent\":\"{}\",\"filter\":{\"sources\":[{\"name\":\"x\"}],\"operations\":[{\"name\":\"x\"}],\"sites\":[{\"name\":\"x\"}],\"operationalDepartments\":[{\"name\":\"x\"}],\"typePlannings\":[{\"name\":\"x\"}],\"customers\":[{\"name\":\"x\"}],\"productionSites\":[{\"name\":\"x\"}],\"transportTypes\":[{\"name\":\"x\"}],\"driverWait\":\"x\"}}]}")
            };
            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.GetFlow(It.IsAny<string>())).Returns(Task.FromResult(responseMessageGetFlow));
            var eccSetupRestApi = eccSetupRestApiMock.Object;

            var usersRestApi = new Mock<IUsersRestApi>().Object;

            var teamsRestApi = new Mock<ITeamsRestApi>().Object;

            var responseMessageGetOrder = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\r\n    \"id\" : \"76122118-5f89-4715-8360-c78d1fa95c1a\"\r\n}")
            };
            responseMessageGetOrder.Headers.Add("ETag", "\"10000000\"");
            var responseMessageUpdateOrder = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };
            responseMessageUpdateOrder.Headers.Add("If-Match", "\"10000000\"");
            var workOrdersRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrdersRestApiMock.Setup(x => x.GetOrder(It.IsAny<string>())).Returns(Task.FromResult(responseMessageGetOrder));
            workOrdersRestApiMock.Setup(x => x.UpdateOrderStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseMessageUpdateOrder));
            var workOrdersRestApi = workOrdersRestApiMock.Object;

            var filterString = "source%20eq%20%27source%27%20and%20operation%20eq%20%27operation%27%20and%20site%20eq%20%27site%27%20and%20department%20eq%20%27operational%20department%27%20and%20type-planning%20eq%20%27Type%20planning%27%20and%20customer%20eq%20%27Customer%27%20and%20prodsite%20eq%20%27Production%20site%27%20and%20transport-type%20eq%20%27Transport%20type%27%20and%20driver-wait%20eq%20%27Yes%27";
            var filterBuildServiceMock = new Mock<IFilterBuildService>();
            filterBuildServiceMock.Setup(x => x.BuildFlowFilter(It.IsAny<FlowFilterFromBody>())).Returns(filterString);
            var filterBuildService = filterBuildServiceMock.Object;

            var filterMapper = new Mock<IFilterMapper>().Object;

            var mapper = new Mock<IMapper>().Object;

            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                 teamsRestApi,
                                                 eccSetupRestApi,
                                                 workOrdersRestApi,
                                                 filterMapper,
                                                 filterBuildService,
                                                 jsonService,
                                                 locationBuildService,
                                                 modelDtoConverter,
                                                 mapper);

            //Act
            var response = await mobileService.GetWorkOrderWithFlow(new StartOrderFromBody() { Id = id, Login = "Karl" });

            //Assert
            response.IsSuccess.Should().Be(true);
        }

        [TestMethod]
        public async Task CreateOperatorActivitiesShouldSucceed()
        {
            //Arrange
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.Created;
            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.CreateOperatorActivities(It.IsAny<string>(), It.IsAny<JObject>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var workOrdersRestapi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrdersRestapi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.CreateOperatorActivities(new JObject());

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task CreateOperatorActivitiesShouldFailWhenEccSetupRestApiFails()
        {
            //Arrange
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.CreateOperatorActivities(It.IsAny<string>(), It.IsAny<JObject>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var workOrdersRestapi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var mapper = new Mock<IMapper>().Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrdersRestapi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.CreateOperatorActivities(new JObject());

            //Assert
            response.IsFailure.Should().BeTrue();
        }

        [TestMethod]
        public async Task UpdateWorkOrderStatusShouldSucceed()
        {
            //Arrange
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var jsonService = new Mock<IJsonService<object>>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.NoContent;
            responseMessage.Headers.ETag = new EntityTagHeaderValue("\"1234567\"");
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrderRestApiMock.Setup(x => x.UpdateOrderStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrderRestApi = workOrderRestApiMock.Object;
            var updateWorkOrderStatusFromBody = new UpdateOrderStatusFromBody
            {
                OrderId = Guid.NewGuid(),
                Status = "Busy",
                Version = "12345555"
            };
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UpdateWorkOrderStatus(updateWorkOrderStatusFromBody);

            //Assert
            response.IsSuccess.Should().Be(true);
        }

        [TestMethod]
        public async Task UpdateWorkOrderStatusShouldFailWhenApiRequestFails()
        {
            //Arrange
            var jsonService = new Mock<IJsonService<object>>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrderRestApiMock.Setup(x => x.UpdateOrderStatus(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrderRestApi = workOrderRestApiMock.Object;
            var updateWorkOrderStatusFromBody = new UpdateOrderStatusFromBody
            {
                OrderId = Guid.NewGuid(),
                Status = "Busy",
                Version = "12345555"
            };
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UpdateWorkOrderStatus(updateWorkOrderStatusFromBody);

            //Assert
            response.IsFailure.Should().Be(true);
        }

        [TestMethod]
        public async Task GetLocationShouldSucceed()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.OK;
            responseMessage.Content = new StringContent("Test", Encoding.UTF8, "application/json");
            var jsonServiceMock = new Mock<IJsonService<object>>();
            jsonServiceMock.Setup(x => x.DeserializeObject<LocationsModel>(It.IsAny<string>())).Returns(new LocationsModel());
            var jsonService = jsonServiceMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildServiceMock = new Mock<IFilterBuildService>();
            filterBuildServiceMock.Setup(x => x.BuildLocationFilter(It.IsAny<GetLocationFromBody>())).Returns("Test");
            var filterBuildService = filterBuildServiceMock.Object;
            var eccRestApiMock = new Mock<IEccSetupRestApi>();
            eccRestApiMock.Setup(x => x.GetLocation(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var eccRestApi = eccRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var service = new MobileService(usersRestApi,
                                            teamsRestApi,
                                            eccRestApi,
                                            workOrderRestApi,
                                            filterMapper,
                                            filterBuildService,
                                            jsonService,
                                            locationBuildService,
                                            modelDtoConverter,
                                            mapper);

            //Act
            var response = await service.GetLocation(new GetLocationFromBody());

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetLocationShouldReturnFailWhenApiCallFails()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            var jsonServiceMock = new Mock<IJsonService<object>>();
            jsonServiceMock.Setup(x => x.DeserializeObject<LocationsModel>(It.IsAny<string>())).Returns(new LocationsModel());
            var jsonService = jsonServiceMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildServiceMock = new Mock<IFilterBuildService>();
            filterBuildServiceMock.Setup(x => x.BuildLocationFilter(It.IsAny<GetLocationFromBody>())).Returns("Test");
            var filterBuildService = filterBuildServiceMock.Object;
            var eccRestApiMock = new Mock<IEccSetupRestApi>();
            eccRestApiMock.Setup(x => x.GetLocation(It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var eccRestApi = eccRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var service = new MobileService(usersRestApi,
                                            teamsRestApi,
                                            eccRestApi,
                                            workOrderRestApi,
                                            filterMapper,
                                            filterBuildService,
                                            jsonService,
                                            locationBuildService,
                                            modelDtoConverter,
                                            mapper);

            //Act
            var response = await service.GetLocation(new GetLocationFromBody());

            //Assert
            response.IsFailure.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetDamageCodesShouldSucceed()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            };
            var jsonServiceMock = new Mock<IJsonService<object>>();
            jsonServiceMock
                .Setup(x => x.DeserializeObject<DamageCodesModel>(It.IsAny<string>()))
                .Returns(new DamageCodesModel());
            var jsonService = jsonServiceMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var eccRestApiMock = new Mock<IEccSetupRestApi>();
            eccRestApiMock
                .Setup(x => x.GetDamageCodes(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));
            var eccRestApi = eccRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var service = new MobileService(usersRestApi,
                                            teamsRestApi,
                                            eccRestApi,
                                            workOrderRestApi,
                                            filterMapper,
                                            filterBuildService,
                                            jsonService,
                                            locationBuildService,
                                            modelDtoConverter,
                                            mapper);

            //Act
            var response = await service.GetDamageCodes();

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetDamageCodesShouldReturnFailWhenApiCallFails()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            };
            var jsonServiceMock = new Mock<IJsonService<object>>();
            jsonServiceMock
                .Setup(x => x.DeserializeObject<DamageCodesModel>(It.IsAny<string>()))
                .Returns(new DamageCodesModel());
            var jsonService = jsonServiceMock.Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var eccRestApiMock = new Mock<IEccSetupRestApi>();
            eccRestApiMock
                .Setup(x => x.GetDamageCodes(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));
            var eccRestApi = eccRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var service = new MobileService(usersRestApi,
                                            teamsRestApi,
                                            eccRestApi,
                                            workOrderRestApi,
                                            filterMapper,
                                            filterBuildService,
                                            jsonService,
                                            locationBuildService,
                                            modelDtoConverter,
                                            mapper);

            //Act
            var response = await service.GetDamageCodes();

            //Assert
            response.IsFailure.Should().BeTrue();
        }

        [TestMethod]
        public async Task UpdateOperationalShouldSucceed()
        {
            //Arrange
            var version = "\"234243244\"";
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.NoContent;
            responseMessage.Headers.ETag = new EntityTagHeaderValue(version);
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrderRestApiMock.Setup(x => x.UpdateOperational(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrderRestApi = workOrderRestApiMock.Object;
            var jsonServiceMock = new Mock<IJsonService<object>>();
            var jsonService = jsonServiceMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UpdateOperational(new UpdateOperationalFromBody());

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task UpdateOperationalShouldFailWhenApiCallFails()
        {
            //Arrange
            var version = "\"234243244\"";
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.BadRequest;
            responseMessage.Headers.ETag = new EntityTagHeaderValue(version);
            var eccSetupRestApi = new Mock<IEccSetupRestApi>().Object;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApiMock = new Mock<IWorkOrdersRestApi>();
            workOrderRestApiMock.Setup(x => x.UpdateOperational(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseMessage));
            var workOrderRestApi = workOrderRestApiMock.Object;
            var jsonServiceMock = new Mock<IJsonService<object>>();
            var jsonService = jsonServiceMock.Object;

            var modelDtoConverterMock = new Mock<IModelDtoConverter>();
            modelDtoConverterMock.Setup(x => x.Convert(It.IsAny<IEnumerable<HandledUnitMobileDto>>())).Returns(new List<HandledUnitDto>());
            var modelDtoConverter = modelDtoConverterMock.Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UpdateOperational(new UpdateOperationalFromBody());

            //Assert
            response.IsFailure.Should().BeTrue();
        }

        [TestMethod]
        public async Task UploadPictureShouldSucceed()
        {
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.Created;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var jsonServiceMock = new Mock<IJsonService<object>>();
            var jsonService = jsonServiceMock.Object;
            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.UploadPicture(It.IsAny<string>(), It.IsAny<IFormFile>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UploadPicture(new UploadPictureFromForm());

            //Assert
            response.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task UploadFileShouldFailWhenApiCallFails()
        {
            var locationBuildService = new Mock<ILocationBuildService>().Object;
            var responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = HttpStatusCode.UnsupportedMediaType;
            var filterBuildService = new Mock<IFilterBuildService>().Object;
            var filterMapper = new Mock<IFilterMapper>().Object;
            var usersRestApi = new Mock<IUsersRestApi>().Object;
            var teamsRestApi = new Mock<ITeamsRestApi>().Object;
            var mapper = new Mock<IMapper>().Object;
            var workOrderRestApi = new Mock<IWorkOrdersRestApi>().Object;
            var jsonServiceMock = new Mock<IJsonService<object>>();
            var jsonService = jsonServiceMock.Object;
            var eccSetupRestApiMock = new Mock<IEccSetupRestApi>();
            eccSetupRestApiMock.Setup(x => x.UploadPicture(It.IsAny<string>(), It.IsAny<IFormFile>())).Returns(Task.FromResult(responseMessage));
            var eccSetupRestApi = eccSetupRestApiMock.Object;
            var modelDtoConverter = new Mock<IModelDtoConverter>().Object;

            var mobileService = new MobileService(usersRestApi,
                                                  teamsRestApi,
                                                  eccSetupRestApi,
                                                  workOrderRestApi,
                                                  filterMapper,
                                                  filterBuildService,
                                                  jsonService,
                                                  locationBuildService,
                                                  modelDtoConverter,
                                                  mapper);

            //Act
            var response = await mobileService.UploadPicture(new UploadPictureFromForm());

            //Assert
            response.IsFailure.Should().BeTrue();
        }
    }
}
