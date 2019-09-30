using ITG.Brix.Mobile.Bff.Application.Models.Local;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api.Location
{
    public class LocationsModel
    {
        public long Count { get; set; }
        public string NextLink { get; set; }
        public IEnumerable<LocationLocalModel> Value { get; set; }
    }
}
