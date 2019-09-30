using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITG.Brix.Mobile.Bff.Application.Services.Jsons
{
    public interface IJsonService<T> where T : class
    {
        string Serialize(object obj, JsonSerializerSettings settings = null);
        T DeserializeObject<T>(string value);
    }
}
