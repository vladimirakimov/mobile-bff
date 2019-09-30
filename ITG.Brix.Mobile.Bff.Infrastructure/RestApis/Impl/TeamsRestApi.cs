using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl
{
    public class TeamsRestApi : ITeamsRestApi
    {
        private readonly HttpClient _httpClient;

        public TeamsRestApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> GetUserTeam(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }
    }
}
