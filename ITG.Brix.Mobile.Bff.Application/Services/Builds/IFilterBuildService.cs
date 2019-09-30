using ITG.Brix.Mobile.Bff.Application.Models.Api;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Services.Builds
{
    public interface IFilterBuildService
    {
        string BuildFlowFilter(FlowFilterFromBody filterData);
        FlowFilterFromBody BuildFlowFilterFromBody(WorkOrderModel workOrder);
        FlowModel GetMostSpecificFlow(List<FlowModel> flows, FlowFilterFromBody filter);
        string BuildLocationFilter(GetLocationFromBody locationFromBody);
    }
}
