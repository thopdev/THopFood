﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThopFood.Blazor.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string controller, int id);
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

        public async Task<T> GetAsync<T>(string controller, int id)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            var uri = new Uri(_httpClient.BaseAddress,  $"api/{controller}/{id}");
            var response = await _httpClient.GetAsync(uri);
            return await ProcessRequestAsync<T>(response);
        }

        private  async Task<T> ProcessRequestAsync<T>(HttpResponseMessage response)
        {
            return await _jsonService.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
        }
    }
}
