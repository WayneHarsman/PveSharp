namespace PveSharp;

public class PveHttpClientBuilder
{
    private HttpClientHandler _handler;
    private bool _disposeHandler;
    private TimeSpan? _timeout;

    public PveHttpClientBuilder()
    {
        _handler = new HttpClientHandler();
        _disposeHandler = true;
        _timeout = null;
    }


    /// <summary>
    /// Configure the HttpClientHandler
    /// </summary>
    /// <param name="handler">Preconfigured handler. If none provided default one is used</param>
    /// <param name="disposeHandler"> True if the inner handler should be disposed of by HttpClient.Dispose;
    /// false if you intend to reuse the inner handler.</param>
    /// <param name="ignoreSslErrors">Disables certificate validation</param>
    /// <returns>Builder</returns>
    public PveHttpClientBuilder WithHandler(HttpClientHandler? handler = null, bool disposeHandler = false,
        bool ignoreSslErrors = false)
    {
        // If no handler was provided we'll use the default one anyway
        if (handler is not null)
            _handler = handler;

        _disposeHandler = disposeHandler;
        if (ignoreSslErrors)
        {
            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        }

        return this;
    }


    public PveHttpClientBuilder WithTimeout(TimeSpan timeout)
    {
        _timeout = timeout;

        return this;
    }


    public HttpClient Build()
    {
        var client = new HttpClient(_handler, _disposeHandler);
        if (_timeout is not null)
            client.Timeout = _timeout.Value;

        return client;
    }
}