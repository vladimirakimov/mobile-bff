using ITG.Brix.Mobile.Bff.Application.Models.Local;
using ITG.Brix.Mobile.Bff.Domain;
using ITG.Brix.Mobile.Bff.Domain.Model.Enums;
using System;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Mappers.Impl
{
    public class FilterMapper : IFilterMapper
    {
        public string ToEscaped(NarrowerModel narrowerModel, string operant)
        {
            string resultTeamNarrower = string.Empty;
            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.Sources);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.Sites);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.Operations);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.OperationalDepartments);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.TypePlannings);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.Customers);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.ProductionSites);

            resultTeamNarrower = GetTeamNarrowerGroupItemsAsFilterString(resultTeamNarrower, narrowerModel.TeamNarrower.TransportTypes);


            if (!string.IsNullOrWhiteSpace(resultTeamNarrower))
            {
                resultTeamNarrower = resultTeamNarrower.Remove(resultTeamNarrower.Length - 5);

                if (resultTeamNarrower.Contains(" and "))
                {
                    resultTeamNarrower = "(" + resultTeamNarrower + ")";
                }
            }

            //2

            var resultLayoutListScreenTabNarrower = GetLayoutTabItemsAsFilterString(narrowerModel.LayoutTabNarrower.Items);

            if (!string.IsNullOrWhiteSpace(resultLayoutListScreenTabNarrower))
            {
                if (resultLayoutListScreenTabNarrower.Contains(" and "))
                {
                    resultLayoutListScreenTabNarrower = "(" + resultLayoutListScreenTabNarrower + ")";
                }
            }

            //3
            string result;
            var mandatoryFilter = Item.OperationalStatus.FilterKey.Value + " eq " + "'" + OrderStatus.Open.ToString()
                + "'" + " or (" + Item.OperationalOperant.FilterKey.Value + " eq " + "'" + operant + "'" + " and "
                + Item.OperationalStatus.FilterKey.Value + " eq " + "'" + OrderStatus.Busy.ToString() + "'" + ")";

            if (string.IsNullOrWhiteSpace(resultTeamNarrower) && !string.IsNullOrWhiteSpace(resultLayoutListScreenTabNarrower))
            {
                result = resultLayoutListScreenTabNarrower;
            }
            else if (!string.IsNullOrWhiteSpace(resultTeamNarrower) && string.IsNullOrWhiteSpace(resultLayoutListScreenTabNarrower))
            {
                result = resultTeamNarrower;
            }
            else if (!string.IsNullOrWhiteSpace(resultTeamNarrower) && !string.IsNullOrWhiteSpace(resultLayoutListScreenTabNarrower))
            {
                result = resultTeamNarrower + " and " + resultLayoutListScreenTabNarrower;
            }
            else
            {
                result = string.Empty;
            }

            var res = "(" + mandatoryFilter + ")" + (string.IsNullOrEmpty(result) ? null : " and " + result);

            return res;
        }

        private string GetTeamNarrowerGroupItemsAsFilterString(string source, IEnumerable<NarrowerItem> teamFilterGroup)
        {
            string result = string.Empty;

            if (teamFilterGroup != null)
            {
                foreach (var item in teamFilterGroup)
                {
                    if (!item.Value.Contains("'"))
                    {
                        result += $"{item.Key} eq '{Uri.EscapeDataString(item.Value)}' or ";
                    }
                }
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Remove(result.Length - 4);
                }
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                result = "(" + result + ") and ";
                source += result;
            }

            return source;
        }

        private string GetLayoutTabItemsAsFilterString(IEnumerable<NarrowerItem> layoutTabItems)
        {
            var result = string.Empty;
            if (layoutTabItems != null)
            {
                foreach (var item in layoutTabItems)
                {
                    if (!item.Value.Contains("'"))
                    {
                        result += $"{item.Key} eq '{Uri.EscapeDataString(item.Value)}' and ";
                    }
                }
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Remove(result.Length - 5);
                }
            }

            return result;
        }
    }
}
