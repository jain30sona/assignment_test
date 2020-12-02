using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Abstraction
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string nextUrl);
    }
}
