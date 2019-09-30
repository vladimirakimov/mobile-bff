using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl
{
    public class UsersRestApi : IUsersRestApi
    {
        private readonly HttpClient _httpClient;

        public UsersRestApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> Login(string requestUri, string jsonBody)
        {
            var result = await _httpClient.PostAsync(requestUri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));
            return result;
        }
    }
}
