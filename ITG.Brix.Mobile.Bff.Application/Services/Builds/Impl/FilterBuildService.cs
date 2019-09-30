using ITG.Brix.Mobile.Bff.Application.Models.Api;
using ITG.Brix.Mobile.Bff.Application.Models.Api.Flows.Bases;
using ITG.Brix.Mobile.Bff.Application.Models.From;
using ITG.Brix.Mobile.Bff.Application.Services.Builds.Matches;
using ITG.Brix.Mobile.Bff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITG.Brix.Mobile.Bff.Application.Services.Builds.Impl
{
    public class FilterBuildService : IFilterBuildService
    {
        public string BuildFlowFilter(FlowFilterFromBody filterData)
        {
            var filter = $"{FilterKey.Source.Value} eq '{filterData.Source}' and {FilterKey.Operation.Value} eq '{filterData.Operation}' and {FilterKey.Site.Value} eq '{filterData.Site}' and {FilterKey.OperationalDepartment.Value} eq '{filterData.OperationalDepartment}' and {FilterKey.TypePlanning.Value} eq '{filterData.TypePlanning}' and {FilterKey.CustomerName.Value} eq '{filterData.Customer}' and {FilterKey.ProductionSite.Value} eq '{filterData.ProductionSite}' and {FilterKey.TransportType.Value} eq '{filterData.TransportType}' and {FilterKey.DriverWait.Value} eq '{filterData.DriverWait}'";
            var escapedFilter = Uri.EscapeDataString(filter);

            return escapedFilter;
        }

        public FlowFilterFromBody BuildFlowFilterFromBody(WorkOrderModel workOrder)
        {
            var flowFilterFromBody = new FlowFilterFromBody
            {
                Source = workOrder.Order.Origin.Source,
                Operation = workOrder.Order.Operation.Name,
                Site = workOrder.Order.Operation.Site,
                Customer = workOrder.Order.Customer.Code,
                OperationalDepartment = workOrder.Order.Operation.OperationalDepartment,
                TypePlanning = workOrder.Order.Operation.TypePlanning,
                TransportType = workOrder.Order.Transport.Type,
                ProductionSite = workOrder.Order.Customer.ProductionSite,
                DriverWait = workOrder.Order.Transport.Driver.Wait
            };

            return flowFilterFromBody;
        }

        public double GetMatchLevel(IEnumerable<BaseFlowFilterPropertyModel> collection, string filterValue)
        {
            double level = 0;

            if (collection.Any(x => x.Name == filterValue))
            {
                level += 100 / collection.Count();
            }

            return level;
        }

        public FlowModel GetMostSpecificFlow(List<FlowModel> flows, FlowFilterFromBody filter)
        {
            var matches = new List<FlowMatch>();

            foreach (var flow in flows)
            {
                double level = 0;

                level += (GetMatchLevel(flow.Filter.Sources, filter.Source) +
                          GetMatchLevel(flow.Filter.Operations, filter.Operation) +
                          GetMatchLevel(flow.Filter.Customers, filter.Customer) +
                          GetMatchLevel(flow.Filter.Sites, filter.Site) +
                          GetMatchLevel(flow.Filter.OperationalDepartments, filter.OperationalDepartment) +
                          GetMatchLevel(flow.Filter.ProductionSites, filter.ProductionSite) +
                          GetMatchLevel(flow.Filter.TransportTypes, filter.TransportType) +
                          GetMatchLevel(flow.Filter.TypePlannings, filter.TypePlanning));

                if (flow.Filter.DriverWait == filter.DriverWait)
                {
                    level += 100;
                }

                matches.Add(new FlowMatch
                {
                    Id = flow.Id,
                    Level = level
                });
            }

            var orderedMatches = matches.OrderBy(x => x.Level);
            var mostSpecificMatch = orderedMatches.LastOrDefault();
            var mostSpecificFlow = flows.Where(x => x.Id == mostSpecificMatch.Id).First();

            return mostSpecificFlow;
        }

        public string BuildLocationFilter(GetLocationFromBody locationFromBody)
        {
            var filter = $"st eq '{locationFromBody.Site}'";
            var escapedFilter = Uri.EscapeUriString(filter);

            return escapedFilter;
        }
    }
}
