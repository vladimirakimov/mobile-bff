using System.Net.Http;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis
{
    public interface ITeamsRestApi
    {
        Task<HttpResponseMessage> GetUserTeam(string requestUri);
    }
}
