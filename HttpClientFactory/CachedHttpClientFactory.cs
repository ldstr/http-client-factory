using System.Net;

namespace HttpClientFactory;

public class CachedHttpClientFactory : IHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Dictionary<int, HttpClient> _cache = new();

    public CachedHttpClientFactory(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public HttpClient CreateClientWithProxy(IWebProxy webProxy)
    {
        var key = webProxy.GetHashCode();

        lock (_cache)
        {
            if (_cache.ContainsKey(key))
                return _cache[key];

            var result = _httpClientFactory.CreateClientWithProxy(
                webProxy
                );

            _cache.Add(key, result);
            return result;
        }
    }
}