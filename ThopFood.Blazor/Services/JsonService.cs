using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ThopFood.Blazor.Services
{
    public interface IJsonService
    {
        string Serialize<T>(T obj);
        Task<T> DeserializeAsync<T>(Stream value);
    }

    public class JsonService : IJsonService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public JsonService(JsonSerializerOptions jsonSerializerOptions)
        {
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _jsonSerializerOptions);
        }

        public async Task<T> DeserializeAsync<T>(Stream value)
        {
            return await JsonSerializer.DeserializeAsync<T>(value, _jsonSerializerOptions);
        }
    }
}