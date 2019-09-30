using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class FlowsModel
    {
        public long Count { get; set; }
        public string NextLink { get; set; }
        public IEnumerable<FlowModel> Value { get; set; }
    }
}
