using System.Net.Http;
using System.Threading.Tasks;

namespace ITG.Brix.Mobile.Bff.Infrastructure.RestApis
{
    public interface IWorkOrdersRestApi
    {
        Task<HttpResponseMessage> GetOrders(string requestUri);
        Task<HttpResponseMessage> GetOrder(string requestUri);
        Task<HttpResponseMessage> UpdateOrder(string requestUri, string version, string status, string login);
        Task<HttpResponseMessage> UpdateOrderStatus(string requestUri, string version, string status);
        Task<HttpResponseMessage> UpdateRemarks(string requestUri, string version, string content);
        Task<HttpResponseMessage> UpdateOperational(string requestUri, string version, string content);
    }
}
