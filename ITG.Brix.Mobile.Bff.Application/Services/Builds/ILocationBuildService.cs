using ITG.Brix.Mobile.Bff.Application.Models.Api.Location;
using ITG.Brix.Mobile.Bff.Application.Models.Mobile.Location;

namespace ITG.Brix.Mobile.Bff.Application.Services.Builds
{
    public interface ILocationBuildService
    {
        LocationSiteModel BuildLocation(LocationsModel locations);
    }
}
