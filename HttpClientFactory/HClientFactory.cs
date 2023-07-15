using System.Net;

namespace HttpClientFactory;

/// <summary>
/// Represents a concrete implementation of the IHttpClientFactory interface.
/// </summary>
public class HClientFactory : IHttpClientFactory
{
    private readonly Func<HttpClientHandler> _makeHandler;

    /// <summary>
    /// Initializes a new instance of the HClientFactory class with the specified HttpClientHandler factory function.
    /// </summary>
    /// <param name="makeHandler">A factory function that creates instances of HttpClientHandler.</param>
    public HClientFactory(Func<HttpClientHandler> makeHandler) =>
        _makeHandler = makeHandler;

    /// <summary>
    /// Creates an HttpClient instance with the specified web proxy.
    /// </summary>
    /// <param name="webProxy">The web proxy to be used by the HttpClient.</param>
    /// <returns>An instance of HttpClient configured with the provided web proxy.</returns>
    public HttpClient CreateClientWithProxy(IWebProxy webProxy)
    {
        var handler = _makeHandler();
        handler.Proxy = webProxy;
        return new(handler, true);
    }
}