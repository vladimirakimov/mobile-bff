using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl
{
    public class WorkOrdersRestApi : IWorkOrdersRestApi
    {
        private readonly HttpClient _httpClient;

        public WorkOrdersRestApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> GetOrders(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }

        public async Task<HttpResponseMessage> GetOrder(string requestUri)
        {
            var result = await _httpClient.GetAsync(requestUri);
            return result;
        }

        public async Task<HttpResponseMessage> UpdateOrder(string requestUri, string version, string status, string operant)
        {
            dynamic order = new JObject();
            order.status = status;
            order.operant = operant;
            order.startedOn = DateTime.UtcNow.ToString("s") + "Z";


            _httpClient.DefaultRequestHeaders.Add(HeaderNames.IfMatch, version);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = new StringContent(order.ToString(), Encoding.UTF8, "application/json") };
            var result = await _httpClient.SendAsync(request);
            _httpClient.DefaultRequestHeaders.Clear();

            return result;
        }

        public async Task<HttpResponseMessage> UpdateRemarks(string requestUri, string version, string content)
        {
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.IfMatch, version);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = new StringContent(content, Encoding.UTF8, "application/json") };
            var result = await _httpClient.SendAsync(request);
            _httpClient.DefaultRequestHeaders.Clear();

            return result;
        }

        public async Task<HttpResponseMessage> UpdateOrderStatus(string requestUri, string version, string status)
        {
            dynamic order = new JObject();
            order.status = status;
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.IfMatch, version);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = new StringContent(order.ToString(), Encoding.UTF8, "application/json") };
            var result = await _httpClient.SendAsync(request);
            _httpClient.DefaultRequestHeaders.Clear();

            return result;
        }

        public async Task<HttpResponseMessage> UpdateOperational(string requestUri, string version, string content)
        {
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.IfMatch, version);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = new StringContent(content, Encoding.UTF8, "application/json") };
            var result = await _httpClient.SendAsync(request);
            _httpClient.DefaultRequestHeaders.Clear();

            return result;
        }
    }
}
