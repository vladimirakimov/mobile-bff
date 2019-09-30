using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis
{
    public interface IEccSetupRestApi
    {
        Task<HttpResponseMessage> GetLayout(string requestUri);
        Task<HttpResponseMessage> GetFlow(string requestUri);
        Task<HttpResponseMessage> CreateOperatorActivities(string requestUri, JObject bodyContent);
        Task<HttpResponseMessage> GetLocation(string requestUri);
        Task<HttpResponseMessage> GetDamageCodes(string requestUri);
        Task<HttpResponseMessage> UploadPicture(string requestUri, IFormFile picture);
    }
}
