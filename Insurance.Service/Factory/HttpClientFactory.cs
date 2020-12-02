using System.Net.Http;
using Insurance.Infrastructure.Abstraction;

namespace Insurance.Infrastructure.Factory
{
    public class HttpClientFactory: IHttpClientFactory
    {
        public HttpClient Create()
        {
            return new HttpClient();
        }
    }
}
