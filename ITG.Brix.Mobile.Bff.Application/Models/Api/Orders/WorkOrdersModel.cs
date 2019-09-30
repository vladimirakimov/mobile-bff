using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class WorkOrdersModel
    {
        public long Count { get; set; }
        public string NextLink { get; set; }
        public IEnumerable<WorkOrderModel> Value { get; set; }
    }
}
