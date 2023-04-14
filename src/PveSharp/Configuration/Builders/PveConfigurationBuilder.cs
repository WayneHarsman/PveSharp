using Microsoft.Extensions.Logging;
using PveSharp.Http;

namespace PveSharp;


//TODO: rewrite this to be actually useful
public class PveConfigurationBuilder
{
    private readonly IPveClientConfiguration _clientConfiguration;
    private Action<IRequest> _OnRequest;

    public PveConfigurationBuilder(IAuthenticator authenticator)
    {
        _clientConfiguration = new PveClientConfiguration(authenticator);
    }
    
    public PveConfigurationBuilder WithHost(string host, int port = 8006)
    {
        _clientConfiguration.Host = host;
        _clientConfiguration.Port = port;
        return this;
    }
    
    public PveConfigurationBuilder WithHttpClient(HttpClient httpClient)
    {
        _clientConfiguration.HttpClient = httpClient;
        return this;
    }

    public PveConfigurationBuilder WithHttpClient(Action<PveHttpClientBuilder> options)
    {
        var builder = new PveHttpClientBuilder();
        options(builder);
        _clientConfiguration.HttpClient = builder.Build();
        return this;
    }

    public PveConfigurationBuilder WithLogger(ILogger logger)
    {
        _clientConfiguration.Logger = logger;
        return this;
    }
    
    public IPveClientConfiguration Build()
    {
        return _clientConfiguration;
    }
}