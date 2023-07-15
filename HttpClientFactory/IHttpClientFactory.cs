using System.Net;

namespace HttpClientFactory;

/// <summary>
/// Represents a factory for creating HttpClient instances.
/// </summary>
public interface IHttpClientFactory
{
    /// <summary>
    /// Creates an HttpClient instance with the specified web proxy.
    /// </summary>
    /// <param name="webProxy">The web proxy to be used by the HttpClient.</param>
    /// <returns>An instance of HttpClient configured with the provided web proxy.</returns>
    HttpClient CreateClientWithProxy(IWebProxy webProxy);
}