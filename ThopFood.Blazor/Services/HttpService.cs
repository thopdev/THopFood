using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace ThopFood.Blazor.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string controller);
        Task<T> GetAsync<T>(string controller, int id);
        Task<T> PostAsync<T>(string controller, object value);
        Task PutAsync(string endpoint, int id, object value);
    }

    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonService _jsonService;

        public HttpService(HttpClient httpClient, IJsonService jsonService)
        {
            _httpClient = httpClient;
            _jsonService = jsonService;

            if (_httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<T> GetAsync<T>(string controller)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var uri = new Uri(_httpClient.BaseAddress, $"api/{controller}");
            return await GetAsync<T>(uri);
        }

        public async Task<T> GetAsync<T>(string controller, int id)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var uri = new Uri(_httpClient.BaseAddress,  $"api/{controller}/{id}");
            return await GetAsync<T>(uri);
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            var response = await _httpClient.GetAsync(uri);
            return await ProcessRequestAsync<T>(response);
        }

        public async Task<T> PostAsync<T>(string controller, object value)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"api/{controller}");
            var response = await _httpClient.PostAsJsonAsync(uri, value);
            return await ProcessRequestAsync<T>(response);
        }

        public async Task PutAsync(string endpoint, int id,  object value)
        {
            var uri = new Uri(_httpClient.BaseAddress, $"api/{endpoint}/{id}");
            await _httpClient.PutAsJsonAsync(uri, value);
        }

        private  async Task<T> ProcessRequestAsync<T>(HttpResponseMessage response)
        {
            return await _jsonService.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
        }
    }
}
