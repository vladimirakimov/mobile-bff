using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location
{
    public class WarehouseModel
    {
        public string Name { get; set; }
        public IList<GateModel> Gates { get; set; }
    }
}
