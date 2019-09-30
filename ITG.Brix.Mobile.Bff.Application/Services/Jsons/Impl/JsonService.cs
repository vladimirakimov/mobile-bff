using Newtonsoft.Json;

namespace ITG.Brix.Mobile.Bff.Application.Services.Jsons.Impl
{
    public class JsonService : IJsonService<object>
    {
        public string Serialize(object obj, JsonSerializerSettings settings = null)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
