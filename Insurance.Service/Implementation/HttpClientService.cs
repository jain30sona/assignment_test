using Insurance.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Implementation
{
    public class HttpClientService : IHttpClientService
    {
        private const string baseAddress = "http://localhost:5002";
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<HttpResponseMessage> GetAsync(string nextUrl)
        {
            var httpClient = CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{baseAddress}{nextUrl}");
            return response;
        }

        private HttpClient CreateClient()
        {
            return _httpClientFactory.Create();
        }
    }
}
