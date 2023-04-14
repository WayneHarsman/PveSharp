using Microsoft.Extensions.Logging;

namespace PveSharp;

public class PveClientConfiguration : IPveClientConfiguration
{
    public string Host { get; set; }
    public int Port { get; set; }
    public IAuthenticator Authenticator { get; set; }
    public HttpClient HttpClient { get; set; }
    public ILogger? Logger { get; set; }

    public PveClientConfiguration(IAuthenticator authenticator)
    {
        Host = "localhost";
        Port = 8006;
        Authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        HttpClient = new HttpClient();
        Logger = new LoggerFactory().CreateLogger<PveClient>();
    }

    public PveClientConfiguration(string host, int port, IAuthenticator authenticator, HttpClient httpClient, Logger<PveClient> logger)
    {
        Host = host;
        Port = port;
        Authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        HttpClient = httpClient;
        Logger = logger;
    }
}