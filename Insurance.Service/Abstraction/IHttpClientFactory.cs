using System.Net.Http;

namespace Insurance.Infrastructure.Abstraction
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}
