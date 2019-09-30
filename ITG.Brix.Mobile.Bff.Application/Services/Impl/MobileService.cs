using AutoMapper;
using CSharpFunctionalExtensions;
using ITG.Brix.Mobile.Bff.Application.Config;
using ITG.Brix.Mobile.Bff.Application.JsonContractResolvers;
using ITG.Brix.Mobile.Bff.Application.Mappers;
using ITG.Brix.Mobile.Bff.Application.Models;
using ITG.Brix.Mobile.Bff.Application.Models.Api;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Damage;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Location;
using ITG.Brix.Mobile.Bff.Application.Models.Content;
using ITG.Brix.Mobile.Bff.Application.Models.Dtos;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Models.Local;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location;
using ITG.Brix.Mobile.Bff.Application.Services.Builds;
using ITG.Brix.Mobile.Bff.Application.Services.Converters;
using ITG.Brix.Mobile.Bff.Application.Services.Jsons;
using ITG.Brix.Mobile.Bff.Domain;
using ITG.Brix.Mobile.Bff.Domain.Model.Enums;
using ITG.Brix.Mobile.Bff.Infrastructure.RestApis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Application.Services.Impl
{
    public class MobileService : IMobileService
    {
        private readonly IUsersRestApi _usersRestApi;
        private readonly ITeamsRestApi _teamsRestApi;
        private readonly IEccSetupRestApi _eccSetupRestApi;
        private readonly IWorkOrdersRestApi _workOrdersRestApi;
        private readonly IFilterMapper _filterMapper;
        private readonly IFilterBuildService _filterBuildService;
        private readonly IJsonService<object> _jsonService;
        private readonly ILocationBuildService _locationBuildService;
        private readonly IModelDtoConverter _modelDtoConverter;
        private readonly IMapper _mapper;

        private const string _apiVersion = "1.0";

        public MobileService(IUsersRestApi usersRestApi,
                             ITeamsRestApi teamsRestApi,
                             IEccSetupRestApi eccSetupRestApi,
                             IWorkOrdersRestApi workOrdersRestApi,
                             IFilterMapper filterMapper,
                             IFilterBuildService filterBuildService,
                             IJsonService<object> jsonService,
                             ILocationBuildService locationBuildService,
                             IModelDtoConverter modelDtoConverter,
                             IMapper mapper)
        {
            _usersRestApi = usersRestApi ?? throw new ArgumentNullException(nameof(usersRestApi));
            _teamsRestApi = teamsRestApi ?? throw new ArgumentNullException(nameof(teamsRestApi));
            _eccSetupRestApi = eccSetupRestApi ?? throw new ArgumentNullException(nameof(eccSetupRestApi));
            _workOrdersRestApi = workOrdersRestApi ?? throw new ArgumentNullException(nameof(workOrdersRestApi));
            _filterMapper = filterMapper ?? throw new ArgumentNullException(nameof(filterMapper));
            _filterBuildService = filterBuildService ?? throw new ArgumentNullException(nameof(filterBuildService));
            _jsonService = jsonService ?? throw new ArgumentNullException(nameof(jsonService));
            _locationBuildService = locationBuildService ?? throw new ArgumentNullException(nameof(locationBuildService));
            _modelDtoConverter = modelDtoConverter ?? throw new ArgumentNullException(nameof(modelDtoConverter));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<AuthenticatedUserModel>> LoginAndGetLayout(LoginFromBody loginFromBody)
        {
            var authenticatedUserModel = new AuthenticatedUserModel();

            var result = await Login(loginFromBody).OnSuccess(async res =>
            {
                authenticatedUserModel.Id = res.Id;
                await GetTeamAsync(res.Id)
                      .OnSuccess(async team =>
                      {
                          authenticatedUserModel.Team = new TeamLocalModel() { Id = team.Id, Name = team.Name };
                          await GetLayoutAsync(team.Layout)
                                .OnSuccess(layout =>
                                {
                                    authenticatedUserModel.Layout = layout.Diagram;
                                });
                      });
            });

            if (result.IsSuccess)
            {
                return Result.Ok(authenticatedUserModel);
            }
            else
            {
                return Result.Fail<AuthenticatedUserModel>(result.Error);
            }
        }

        public async Task<Result<List<OrderItem>>> GetOrders(FiltersFromBody filters)
        {
            var narrowerModel = GetNarrowerModel(filters.TeamId, filters.TabFilters);

            var result = await GetOrdersAsync(narrowerModel, filters.Operant);

            var orderOverviews = GetOrderItems(result.Value, filters.ItemKeys).ToList();

            return Result.Ok(orderOverviews);
        }

        private IList<OrderItem> GetOrderItems(WorkOrdersModel workOrdersModel, IEnumerable<string> orderItemsKeys)
        {
            List<WorkOrderModel> woList = workOrdersModel.Value.ToList();
            List<OrderItem> orderOverviews = new List<OrderItem>();
            foreach (var wo in woList)
            {
                List<OrderItemPropsModel> PropsList = new List<OrderItemPropsModel>();
                foreach (var orderItemKey in orderItemsKeys)
                {
                    PropsList.Add(new OrderItemPropsModel { Key = orderItemKey, Value = wo.Get(orderItemKey) });
                }
                orderOverviews.Add(new OrderItem { Id = wo.Id, CreatedOn = wo.CreatedOn, Props = PropsList });
            }

            return orderOverviews;
        }

        private NarrowerModel GetNarrowerModel(string teamId, IDictionary<string, string> tabFilters)
        {
            var teamNarrower = GetTeamNarrower(teamId);
            var layoutTabNarrower = GetLayoutTabNarrower(tabFilters);

            var result = new NarrowerModel
            {
                TeamNarrower = teamNarrower,
                LayoutTabNarrower = layoutTabNarrower
            };
            return result;
        }

        private TeamNarrowerModel GetTeamNarrower(string teamId)
        {
            var teamFilters = GetTeamFilters(teamId);
            var teamFilterModel = JsonConvert.DeserializeObject<TeamFilterModel>(teamFilters.Result.Value);
            if (teamFilterModel.Sources == null)
            {
                teamFilterModel.Sources = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.Sites == null)
            {
                teamFilterModel.Sites = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.Operations == null)
            {
                teamFilterModel.Operations = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.OperationalDepartments == null)
            {
                teamFilterModel.OperationalDepartments = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.TypePlannings == null)
            {
                teamFilterModel.TypePlannings = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.Customers == null)
            {
                teamFilterModel.Customers = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.ProductionSites == null)
            {
                teamFilterModel.ProductionSites = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.TransportTypes == null)
            {
                teamFilterModel.TransportTypes = Enumerable.Empty<NameModel>().ToList();
            }
            if (teamFilterModel.DriverWait != "Unspecified" && teamFilterModel.DriverWait != "Yes" && teamFilterModel.DriverWait != "No")
            {
                teamFilterModel.DriverWait = "Unspecified";
            }
            var result = new TeamNarrowerModel()
            {
                Sources = teamFilterModel.Sources.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.Source), Value = x.Name }).ToList(),
                Sites = teamFilterModel.Sites.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.Site), Value = x.Name }).ToList(),
                Operations = teamFilterModel.Operations.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.Operation), Value = x.Name }).ToList(),
                OperationalDepartments = teamFilterModel.OperationalDepartments.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.OperationalDepartment), Value = x.Name }).ToList(),
                TypePlannings = teamFilterModel.TypePlannings.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.TypePlanning), Value = x.Name }).ToList(),
                Customers = teamFilterModel.Customers.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.CustomerName), Value = x.Name }).ToList(),
                ProductionSites = teamFilterModel.ProductionSites.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.ProductionSite), Value = x.Name }).ToList(),
                TransportTypes = teamFilterModel.TransportTypes.Select(x => new NarrowerItem { Key = Item.GetPath(ItemKey.TransportType), Value = x.Name }).ToList(),
                DriverWait = new NarrowerItem { Key = Item.GetPath(ItemKey.DriverWait), Value = teamFilterModel.DriverWait }

            };

            return result;
        }

        private LayoutTabNarrowerModel GetLayoutTabNarrower(IDictionary<string, string> tabFilters)
        {
            var result = new LayoutTabNarrowerModel()
            {
                Items = tabFilters.Select(x => new NarrowerItem { Key = Item.GetPath(x.Key), Value = x.Value }).ToList()
            };
            return result;
        }

        private async Task<Result<string>> GetTeamFilters(string teamId)
        {

            var response = await _teamsRestApi.GetUserTeam($"{UrlsConfig.Teams}{UrlsConfig.TeamsOperations.Get(_apiVersion, teamId)}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Fail<string>("Bad request to Teams.API");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var teamsModel = JsonConvert.DeserializeObject<TeamModel>(responseAsString);

                return Result.Ok(teamsModel.FilterContent);
            }
        }

        private async Task<Result<UserModel>> Login(LoginFromBody loginFromBody)
        {
            var jsonBody = JsonConvert.SerializeObject(loginFromBody);

            var response = await _usersRestApi.Login($"{UrlsConfig.Users}{UrlsConfig.UsersOperations.Login(_apiVersion)}", jsonBody);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                return Result.Fail<UserModel>("Invalid credentials");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var authenticatedUser = JsonConvert.DeserializeObject<UserModel>(responseAsString);
                return Result.Ok(authenticatedUser);
            }
        }

        private async Task<Result<TeamLocalModel>> GetTeamAsync(Guid userId)
        {
            var filter = $"members/id eq '{userId}'";

            var response = await _teamsRestApi.GetUserTeam($"{UrlsConfig.Teams}{UrlsConfig.TeamsOperations.List(_apiVersion, filter)}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Fail<TeamLocalModel>("Bad request to Teams.API");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var teamsModel = JsonConvert.DeserializeObject<TeamsModel>(responseAsString);

                var firstTeam = teamsModel.Value.First();
                var result = new TeamLocalModel() { Id = firstTeam.Id.ToString(), Name = firstTeam.Name, Layout = firstTeam.Layout };

                return Result.Ok(result);
            }
        }

        private async Task<Result<LayoutModel>> GetLayoutAsync(Guid layoutId)
        {
            var response = await _eccSetupRestApi.GetLayout($"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.GetLayout(_apiVersion, layoutId)}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Fail<LayoutModel>("Bad request to EccSetup.API");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LayoutModel>(responseAsString);
                //var layoutAsString = "{\"id\":\"db0b6c5b-718c-4787-92a5-d2b2661fc5c6\",\"offsetX\":0,\"offsetY\":0,\"zoom\":100,\"gridSize\":0,\"links\":[{\"id\":\"be8624db-3812-485a-b4bd-3db8ba4a2701\",\"type\":\"default\",\"selected\":false,\"source\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"sourcePort\":\"bbeeb1bf-c64b-43ba-ad42-283d13cd8f22\",\"target\":\"ad7d2b10-bad7-4f64-ae70-d2aeacb48a52\",\"targetPort\":\"f4f6199c-59ab-41fa-810a-99e214f27477\",\"points\":[{\"id\":\"d7ddae00-88c3-4857-835f-a5fe1adb180d\",\"selected\":false,\"x\":460.5,\"y\":190},{\"id\":\"a4bb084c-d9c1-4f9b-842a-25258474c2e0\",\"selected\":false,\"x\":585.5,\"y\":131}],\"extras\":{},\"labels\":[],\"width\":3,\"color\":\"rgba(255,255,255,0.5)\",\"curvyness\":50},{\"id\":\"e97d1fec-c9c0-449b-9287-522063425892\",\"type\":\"default\",\"selected\":false,\"source\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"sourcePort\":\"ec09dd7a-88d0-486f-811b-23417205a865\",\"target\":\"9e6bfadf-d124-4289-900a-7c69ee8d4aa8\",\"targetPort\":\"bb3ad7ed-cae2-4432-845b-c09ebfdd2e73\",\"points\":[{\"id\":\"634f137f-f4ec-45e9-a52f-f3983ebe8f22\",\"selected\":false,\"x\":460.5,\"y\":230},{\"id\":\"21f3c3a2-b71e-4a67-9dec-4f1f6c786dd4\",\"selected\":true,\"x\":586.5,\"y\":367}],\"extras\":{},\"labels\":[],\"width\":3,\"color\":\"rgba(255,255,255,0.5)\",\"curvyness\":50}],\"nodes\":[{\"id\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"type\":\"buttonscreen\",\"selected\":false,\"x\":130,\"y\":85,\"extras\":{},\"ports\":[{\"id\":\"34f0170e-3351-4f8d-bffb-8c836c864d56\",\"type\":\"default\",\"selected\":false,\"name\":\"input\",\"parentNode\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"links\":[],\"in\":true,\"label\":\"input\"},{\"id\":\"bbeeb1bf-c64b-43ba-ad42-283d13cd8f22\",\"type\":\"buttonport\",\"selected\":false,\"name\":\"Warehouse\",\"parentNode\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"links\":[\"be8624db-3812-485a-b4bd-3db8ba4a2701\"],\"maximumLinks\":1,\"description\":\"\",\"image\":\"load_pallets\",\"filters\":[]},{\"id\":\"ec09dd7a-88d0-486f-811b-23417205a865\",\"type\":\"buttonport\",\"selected\":false,\"name\":\"Silo\",\"parentNode\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"links\":[\"e97d1fec-c9c0-449b-9287-522063425892\"],\"maximumLinks\":1,\"description\":\"\",\"image\":\"silos\",\"filters\":[]},{\"id\":\"dc35f997-cd01-4539-8c76-e270c4e44c32\",\"type\":\"buttonport\",\"selected\":false,\"name\":\"VNA\",\"parentNode\":\"6e97d531-855e-4947-87c6-2526dd585741\",\"links\":[],\"maximumLinks\":1,\"description\":\"\",\"image\":\"vna\",\"filters\":[]}],\"name\":\"My Button Screen\"},{\"id\":\"ad7d2b10-bad7-4f64-ae70-d2aeacb48a52\",\"type\":\"listscreen\",\"selected\":false,\"x\":574,\"y\":88,\"extras\":{},\"ports\":[{\"id\":\"f4f6199c-59ab-41fa-810a-99e214f27477\",\"type\":\"default\",\"selected\":false,\"name\":\"input\",\"parentNode\":\"ad7d2b10-bad7-4f64-ae70-d2aeacb48a52\",\"links\":[\"be8624db-3812-485a-b4bd-3db8ba4a2701\"],\"in\":true,\"label\":\"input\"}],\"name\":\"My List Screen\",\"tabs\":[]},{\"id\":\"9e6bfadf-d124-4289-900a-7c69ee8d4aa8\",\"type\":\"listscreen\",\"selected\":false,\"x\":575,\"y\":324,\"extras\":{},\"ports\":[{\"id\":\"bb3ad7ed-cae2-4432-845b-c09ebfdd2e73\",\"type\":\"default\",\"selected\":false,\"name\":\"input\",\"parentNode\":\"9e6bfadf-d124-4289-900a-7c69ee8d4aa8\",\"links\":[\"e97d1fec-c9c0-449b-9287-522063425892\"],\"in\":true,\"label\":\"input\"}],\"name\":\"My List Screen\",\"tabs\":[]}]}";

                return Result.Ok(result);
            }
        }

        private async Task<Result<WorkOrdersModel>> GetOrdersAsync(NarrowerModel narrowerModel, string operant)
        {
            var escapedFilterString = _filterMapper.ToEscaped(narrowerModel, operant);

            var response = await _workOrdersRestApi.GetOrders($"{UrlsConfig.WorkOrders}{UrlsConfig.WorkOrdersOperations.List(_apiVersion, escapedFilterString)}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Fail<WorkOrdersModel>("Bad request to WorkOrders.API");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var workOrdersModel = JsonConvert.DeserializeObject<WorkOrdersModel>(responseAsString);
                return Result.Ok(workOrdersModel);
            }
        }

        public async Task<Result<FlowDataModel>> GetFlow(FlowFilterFromBody filterData)
        {
            var filter = _filterBuildService.BuildFlowFilter(filterData);
            var response = await _eccSetupRestApi.GetFlow($"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.ListFlows(_apiVersion, filter)}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Fail<FlowDataModel>("Bad request to EccSetup.API");
            }
            else
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                var flowsModel = JsonConvert.DeserializeObject<FlowsModel>(responseAsString);

                if (flowsModel.Count == 0)
                {
                    return Result.Fail<FlowDataModel>("No flow found for current order, please contact the administrator!");
                }

                var flows = flowsModel.Value;
                var mostSpecificFlow = _filterBuildService.GetMostSpecificFlow(flows.ToList(), filterData);

                var result = _mapper.Map<FlowDataModel>(mostSpecificFlow);

                return Result.Ok(result);
            }
        }

        public async Task<Result<WorkOrderModel>> GetWorkOrderById(Guid orderId)
        {
            var response = await _workOrdersRestApi.GetOrder($"{UrlsConfig.WorkOrders}{UrlsConfig.WorkOrdersOperations.Get(_apiVersion, orderId)}");
            var responseAsString = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var version = response.Headers.ETag.Tag;

                var result = JsonConvert.DeserializeObject<WorkOrderModel>(responseAsString);
                result.Version = version;

                return Result.Ok(result);
            }
            else
            {
                return Result.Fail<WorkOrderModel>(responseAsString);
            }
        }

        public async Task<Result<string>> MarkWorkOrderStarted(MarkOrderStartedFromBody startedFromBody)
        {
            var response = await _workOrdersRestApi.UpdateOrder($"{UrlsConfig.WorkOrders}{UrlsConfig.WorkOrdersOperations.Update(_apiVersion, startedFromBody.OrderId)}", startedFromBody.Version, OrderStatus.Busy.ToString(), startedFromBody.Operant);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return Result.Ok(response.Headers.ETag.Tag);
            }
            else
            {
                return Result.Fail<string>("Bad request to WorkOrders.API");
            }
        }

        public async Task<Result<string>> UpdateWorkOrderStatus(UpdateOrderStatusFromBody updateFromBody)
        {
            var response = await _workOrdersRestApi.UpdateOrderStatus($"{UrlsConfig.WorkOrders}{UrlsConfig.WorkOrdersOperations.Update(_apiVersion, updateFromBody.OrderId)}", updateFromBody.Version, updateFromBody.Status);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return Result.Ok(response.Headers.ETag.Tag);
            }
            else
            {
                return Result.Fail<string>("Bad request to WorkOrders.API");
            }
        }

        public async Task<Result<WorkOrderWithFlowModel>> GetWorkOrderWithFlow(StartOrderFromBody startOrderFromBody)
        {
            var orderId = startOrderFromBody.Id;
            var login = startOrderFromBody.Login;
            var workOrderWithFlowModel = new WorkOrderWithFlowModel();
            Result result;

            result = await GetWorkOrderById(orderId).OnSuccess(async order =>
            {
                workOrderWithFlowModel.WorkOrder = order;
                var version = order.Version;
                var flowFilterFromBody = _filterBuildService.BuildFlowFilterFromBody(order);

                result = await GetFlow(flowFilterFromBody).OnSuccess(flow =>
                {
                    workOrderWithFlowModel.Flow = flow;
                });

            });

            if (result.IsSuccess)
            {
                return Result.Ok(workOrderWithFlowModel);
            }
            else
            {
                return Result.Fail<WorkOrderWithFlowModel>(result.Error);
            }
        }

        public async Task<Result> CreateOperatorActivities(JObject content)
        {
            var uri = $"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.CreateActivities(_apiVersion)}";
            var response = await _eccSetupRestApi.CreateOperatorActivities(uri, content);
            Result result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                result = Result.Fail("Bad request to EccSetup.API");
            }
            else if (response.StatusCode == HttpStatusCode.Created)
            {
                result = Result.Ok();
            }

            return result;
        }

        public async Task<Result<LocationSiteModel>> GetLocation(GetLocationFromBody getLocationFromBody)
        {
            var filter = _filterBuildService.BuildLocationFilter(getLocationFromBody);
            var response = await _eccSetupRestApi.GetLocation($"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.GetLocation(_apiVersion, filter)}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var contentAsString = await response.Content.ReadAsStringAsync();
                var locationsModel = _jsonService.DeserializeObject<LocationsModel>(contentAsString);
                var locationModel = _locationBuildService.BuildLocation(locationsModel);

                return Result.Ok(locationModel);
            }
            else
            {
                return Result.Fail<LocationSiteModel>("Error on getting location");
            }
        }

        public async Task<Result<IEnumerable<DamageCodeModel>>> GetDamageCodes()
        {
            var response = await _eccSetupRestApi.GetDamageCodes($"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.GetDamageCodes(_apiVersion)}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var contentAsString = await response.Content.ReadAsStringAsync();
                var damageCodeApiModels = _jsonService.DeserializeObject<DamageCodesModel>(contentAsString);
                var damageCodeModels = damageCodeApiModels.Value;

                return Result.Ok(damageCodeModels);
            }
            else
            {
                return Result.Fail<IEnumerable<DamageCodeModel>>("Error on getting damage");
            }
        }

        public async Task<Result<string>> UpdateOperational(UpdateOperationalFromBody operationalFromBody)
        {
            var updateOperationalContent = _mapper.Map<UpdateOperationalContent>(operationalFromBody);
            if (updateOperationalContent == null)
            {
                updateOperationalContent = new UpdateOperationalContent();
            }
            updateOperationalContent.Units = _modelDtoConverter.Convert(operationalFromBody.Units);


            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreEmptyEnumerablesResolver()
            };
            var content = _jsonService.Serialize(updateOperationalContent, serializerSettings);

            var response = await _workOrdersRestApi.UpdateOperational($"{UrlsConfig.WorkOrders}{UrlsConfig.WorkOrdersOperations.Update(_apiVersion, operationalFromBody.OrderId)}", operationalFromBody.Version, content);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return Result.Ok(response.Headers.ETag.Tag);
            }
            else
            {
                return Result.Fail<string>("Error on updating operational.");
            }
        }

        public async Task<Result> UploadPicture(UploadPictureFromForm uploadPictureFromForm)
        {
            var response = await _eccSetupRestApi.UploadPicture($"{UrlsConfig.EccSetup}{UrlsConfig.EccSetupOperations.UploadPicture(_apiVersion)}", uploadPictureFromForm.File);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Error on uploading picture.");
            }
        }
    }
}
