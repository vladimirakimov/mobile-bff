using ITG.Brix.Mobile.Bff.Application.Models.Api;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile
{
    public class WorkOrderWithFlowModel
    {
        public FlowDataModel Flow { get; set; }
        public WorkOrderModel WorkOrder { get; set; }
    }
}
