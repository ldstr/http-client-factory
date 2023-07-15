using System.Net;

namespace HttpClientFactory;

/// <summary>
/// Represents a cached implementation of the IHttpClientFactory interface.
/// </summary>
public class CachedHttpClientFactory : IHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Dictionary<int, HttpClient> _cache = new();

    /// <summary>
    /// Initializes a new instance of the CachedHttpClientFactory class with the specified IHttpClientFactory implementation.
    /// </summary>
    /// <param name="httpClientFactory">An instance of IHttpClientFactory used to create HttpClient instances.</param>
    public CachedHttpClientFactory(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    /// <summary>
    /// Creates an HttpClient instance with the specified web proxy. If the same web proxy has been used before, a cached instance will be returned.
    /// </summary>
    /// <param name="webProxy">The web proxy to be used by the HttpClient.</param>
    /// <returns>An instance of HttpClient configured with the provided web proxy.</returns>
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