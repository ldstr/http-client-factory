using System.Net;

namespace HttpClientFactory;

public class HClientFactory : IHttpClientFactory
{
    private readonly Func<HttpClientHandler> _makeHandler;

    public HClientFactory(Func<HttpClientHandler> makeHandler) =>
        _makeHandler = makeHandler;

    public HttpClient CreateClientWithProxy(IWebProxy webProxy)
    {
        var handler = _makeHandler();
        handler.Proxy = webProxy;
        return new(handler, true);
    }
}