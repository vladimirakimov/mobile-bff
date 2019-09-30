using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location
{
    public class LocationSiteModel
    {
        public string Site { get; set; }
        public IList<WarehouseModel> Warehouses { get; set; }
    }
}
