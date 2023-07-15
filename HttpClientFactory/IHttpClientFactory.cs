using System.Net;

namespace HttpClientFactory;

public interface IHttpClientFactory
{
    HttpClient CreateClientWithProxy(IWebProxy webProxy);
}