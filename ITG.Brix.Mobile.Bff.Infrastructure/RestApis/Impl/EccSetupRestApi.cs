using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl
{
    public class EccSetupRestApi : IEccSetupRestApi
    {
        private readonly HttpClient _httpClient;

        public EccSetupRestApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> GetLayout(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }

        public async Task<HttpResponseMessage> GetFlow(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }

        public async Task<HttpResponseMessage> CreateOperatorActivities(string requestUri, JObject bodyContent)
        {
            var result = await _httpClient.PostAsync(requestUri, new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json"));
            return result;
        }

        public async Task<HttpResponseMessage> GetLocation(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }

        public Task<HttpResponseMessage> GetDamageCodes(string requestUri)
        {
            return _httpClient.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> UploadPicture(string requestUri, IFormFile picture)
        {
            HttpResponseMessage response;

            using (var formData = new MultipartFormDataContent())
            {
                var content = new StreamContent(picture.OpenReadStream());
                content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                formData.Add(content, "File", picture.FileName);

                response = await _httpClient.PostAsync(requestUri, formData);
            }

            return response;
        }
    }
}
