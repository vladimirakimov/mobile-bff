using System.Net.Http;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis
{
    public interface IUsersRestApi
    {
        Task<HttpResponseMessage> Login(string requestUri, string jsonBody);
    }
}
