using CSharpFunctionalExtensions;
using ITG.Brix.Mobile.Bff.Application.Models;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Damage;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Application.Services
{
    public interface IMobileService
    {
        Task<Result<AuthenticatedUserModel>> LoginAndGetLayout(LoginFromBody loginFromBody);
        Task<Result<List<OrderItem>>> GetOrders(FiltersFromBody filters);
        Task<Result<FlowDataModel>> GetFlow(FlowFilterFromBody filterData);
        Task<Result<WorkOrderWithFlowModel>> GetWorkOrderWithFlow(StartOrderFromBody startOrderFromBody);
        Task<Result> CreateOperatorActivities(JObject activities);
        Task<Result<string>> UpdateWorkOrderStatus(UpdateOrderStatusFromBody updateFromBody);
        Task<Result<string>> MarkWorkOrderStarted(MarkOrderStartedFromBody startedFromBody);
        Task<Result<LocationSiteModel>> GetLocation(GetLocationFromBody getLocationFromBody);
        Task<Result<IEnumerable<DamageCodeModel>>> GetDamageCodes();
        Task<Result<string>> UpdateOperational(UpdateOperationalFromBody updateOperationalFromBody);
        Task<Result> UploadPicture(UploadPictureFromForm uploadPictureFromForm);
    }
}
